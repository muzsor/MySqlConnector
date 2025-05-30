#if !MYSQL_DATA
using System.Net;
using System.Net.Sockets;

namespace IntegrationTests;

public class RedirectionTests : IClassFixture<DatabaseFixture>, IDisposable
{
	public RedirectionTests(DatabaseFixture database)
	{
		m_database = database;
		m_database.Connection.Open();
	}

	public void Dispose()
	{
		m_database.Connection.Close();
	}

	[SkippableFact(ServerFeatures.Redirection)]
	public void RedirectionTest()
	{
		StartProxy();

		// wait for proxy to launch
		Thread.Sleep(50);
		var csb = AppConfig.CreateConnectionStringBuilder();
		var initialServer = csb.Server;
		var initialPort = csb.Port;
		m_database.Connection.Execute($"set @@global.redirect_url=\"mariadb://{initialServer}:{initialPort}\"");

		try
		{
			// changing to proxy port
			csb.Server = "localhost";
			csb.Port = (uint)proxy.ListenPort;
			csb.ServerRedirectionMode = MySqlServerRedirectionMode.Preferred;

			// ensure that connection has been redirected
			using (var db = new MySqlConnection(csb.ConnectionString))
			{
				db.Open();
				using (var cmd = db.CreateCommand())
				{
					cmd.CommandText = "SELECT 1";
					cmd.ExecuteNonQuery();
				}

				Assert.Equal((int) initialPort, db.SessionEndPoint!.Port);
				db.Close();
			}

			// ensure that connection has been redirected with Required
			csb.ServerRedirectionMode = MySqlServerRedirectionMode.Required;
			using (var db = new MySqlConnection(csb.ConnectionString))
			{
				db.Open();
				using (var cmd = db.CreateCommand())
				{
					cmd.CommandText = "SELECT 1";
					cmd.ExecuteNonQuery();
				}

				Assert.Equal((int) initialPort, db.SessionEndPoint!.Port);
				db.Close();
			}

			// ensure that redirection is not done
			csb.ServerRedirectionMode = MySqlServerRedirectionMode.Disabled;
			using (var db = new MySqlConnection(csb.ConnectionString))
			{
				db.Open();
				using (var cmd = db.CreateCommand())
				{
					cmd.CommandText = "SELECT 1";
					cmd.ExecuteNonQuery();
				}

				Assert.Equal(proxy.ListenPort, db.SessionEndPoint!.Port);
				db.Close();
			}
		}
		finally
		{
			m_database.Connection.Execute($"set @@global.redirect_url=\"\"");
		}
		MySqlConnection.ClearAllPools();

		// ensure that when required, throwing error if no redirection
		csb.ServerRedirectionMode = MySqlServerRedirectionMode.Required;
		using (var db = new MySqlConnection(csb.ConnectionString))
		{
			var exception = Assert.Throws<MySqlException>(db.Open);
			Assert.Equal(MySqlErrorCode.UnableToConnectToHost, exception.ErrorCode);
		}

		StopProxy();
	}

	protected void StartProxy()
	{
		var csb = AppConfig.CreateConnectionStringBuilder();
		proxy = new ServerConfiguration( csb.Server, (int)csb.Port );
		Thread serverThread = new Thread( ServerThread );
		serverThread.Start( proxy );
	}

	protected void StopProxy()
	{
		proxy.RunServer = false;
		proxy.ServerSocket.Close();
	}

	private class ServerConfiguration
	{
		public IPAddress RemoteAddress { get; set; }
		public int RemotePort { get; set; }
		public int ListenPort { get; set; }
		public Socket ServerSocket { get; set; }
		public ServerConfiguration(string remoteAddress, int remotePort)
		{
			var ipHostEntry = Dns.GetHostEntry(remoteAddress);
			RemoteAddress = ipHostEntry.AddressList[0];
			RemotePort = remotePort;
			ListenPort = 0;
		}
		public bool RunServer { get; set; } = true;
	}

	private static void ServerThread(object configObj)
	{
		ServerConfiguration config = (ServerConfiguration)configObj;
		Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		serverSocket.Bind( new IPEndPoint( IPAddress.Any, 0 ) );
		serverSocket.Listen(1);
		config.ListenPort = ((IPEndPoint) serverSocket.LocalEndPoint).Port;
		config.ServerSocket = serverSocket;
		while (config.RunServer)
		{
			try
			{
				Socket client = serverSocket.Accept();
				Thread clientThread = new Thread(ClientThread);
				clientThread.Start(new ClientContext() { Config = config, Client = client });
			}
			catch (SocketException) when (!config.RunServer)
			{
				return;
			}
		}
	}

	private class ClientContext
	{
		public ServerConfiguration Config { get; set; }
		public Socket Client { get; set; }
	}

	private static void ClientThread(object contextObj)
	{
		ClientContext context = (ClientContext) contextObj;
		Socket client = context.Client;
		ServerConfiguration config = context.Config;
		IPEndPoint remoteEndPoint = new IPEndPoint(config.RemoteAddress, config.RemotePort);
		Socket remote = new Socket(remoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		remote.Connect(remoteEndPoint);
		var buffer = new byte[4096];
		while (true)
		{
			if (!config.RunServer)
			{
				remote.Close();
				client.Close();
				return;
			}
			if (client.Available > 0)
			{
				var count = client.Receive(buffer);
				if (count == 0)
					return;
				remote.Send(buffer, count, SocketFlags.None);
			}
			if (remote.Available > 0)
			{
				var count = remote.Receive(buffer);
				if (count == 0)
					return;
				client.Send(buffer, count, SocketFlags.None);
			}
		}
	}

	private readonly DatabaseFixture m_database;
	private ServerConfiguration proxy;
}
#endif
