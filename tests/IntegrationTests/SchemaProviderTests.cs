#nullable enable
namespace IntegrationTests;

public class SchemaProviderTests : IClassFixture<SchemaProviderFixture>, IDisposable
{
	public SchemaProviderTests(SchemaProviderFixture database)
	{
		m_database = database;
		m_database.Connection.Open();
	}

	public void Dispose()
	{
		m_database.Connection.Close();
	}

	[Fact]
	public void GetDataSourceInformationSchemaCollection()
	{
		var dataTable = m_database.Connection.GetSchema(DbMetaDataCollectionNames.DataSourceInformation);
		Assert.Equal(m_database.Connection.ServerVersion, dataTable.Rows[0]["DataSourceProductVersion"]);
	}

	[Theory]
	[InlineData("ReservedWords")]
	[InlineData("RESERVEDWORDS")]
	[InlineData("reservedwords")]
	public void ReservedWordsSchema(string schemaName)
	{
		var table = m_database.Connection.GetSchema(schemaName);
		Assert.NotNull(table);
		Assert.Single(table.Columns);
		Assert.Equal("ReservedWord", table.Columns[0].ColumnName);
		Assert.Contains("CREATE", table.Rows.Cast<DataRow>().Select(x => (string) x[0]));
	}

	[Fact]
	public void ColumnsSchema()
	{
		var table = m_database.Connection.GetSchema("Columns");
		Assert.NotNull(table);
		AssertHasColumn("TABLE_CATALOG", typeof(string));
		AssertHasColumn("TABLE_SCHEMA", typeof(string));
		AssertHasColumn("TABLE_NAME", typeof(string));
		AssertHasColumn("COLUMN_NAME", typeof(string));
		AssertHasColumn("ORDINAL_POSITION", typeof(uint));
		AssertHasColumn("COLUMN_DEFAULT", typeof(string));
		AssertHasColumn("IS_NULLABLE", typeof(string));
		AssertHasColumn("DATA_TYPE", typeof(string));
		AssertHasColumn("CHARACTER_MAXIMUM_LENGTH", typeof(long));
		AssertHasColumn("NUMERIC_PRECISION", typeof(ulong));
		AssertHasColumn("NUMERIC_SCALE", typeof(ulong));
		AssertHasColumn("DATETIME_PRECISION", typeof(uint));
		AssertHasColumn("CHARACTER_SET_NAME", typeof(string));
		AssertHasColumn("COLLATION_NAME", typeof(string));
		AssertHasColumn("COLUMN_KEY", typeof(string));
		AssertHasColumn("EXTRA", typeof(string));
		AssertHasColumn("PRIVILEGES", typeof(string));
		AssertHasColumn("COLUMN_COMMENT", typeof(string));

		void AssertHasColumn(string name, Type type)
		{
			var column = table.Columns[name];
			Assert.NotNull(column);

			// allow integral types with a larger positive range
			if (type == typeof(int))
				Assert.True(type == typeof(int) || type == typeof(uint) || type == typeof(long) || type == typeof(ulong));
			else if (type == typeof(uint))
				Assert.True(type == typeof(uint) || type == typeof(long) || type == typeof(ulong));
			else if (type == typeof(long))
				Assert.True(type == typeof(long) || type == typeof(ulong));
			else
				Assert.Equal(type, column.DataType);
		}
	}

	[Fact(Skip = "Doesn't work on all server versions")]
	public void ColumnsRestriction()
	{
		var table = m_database.Connection.GetSchema("Columns", new[] { null, null, null, "Bit32" });
		Assert.NotNull(table);
		Assert.Equal(1, table.Rows.Count);
		Assert.Equal("datatypes_bits", table.Rows[0]["TABLE_NAME"]);
		Assert.Equal("Bit32", table.Rows[0]["COLUMN_NAME"]);
	}

	[Fact]
	public void SchemaRestrictionCount()
	{
		var metadata = m_database.Connection.GetSchema("MetaDataCollections");
		var restrictions = m_database.Connection.GetSchema("Restrictions");
		foreach (DataRow row in metadata.Rows)
		{
			var schema = (string) row["CollectionName"];
#if MYSQL_DATA
			if (schema is "Views" or "ViewColumns" or "Triggers")
				continue;
#endif

			var restrictionCount = (int) row["NumberOfRestrictions"];
			var actualCount = restrictions.Rows.Cast<DataRow>().Count(x => (string) x["CollectionName"] == schema);
			Assert.Equal(restrictionCount, actualCount);
		}
	}

#if !MYSQL_DATA
	[Fact]
	public void ExcessColumnsRestriction() =>
		Assert.Throws<ArgumentException>(() => m_database.Connection.GetSchema("Columns", new[] { "1", "2", "3", "4", "too many" }));

	[Fact]
	public void MetaDataCollectionsRestriction() =>
		Assert.Throws<ArgumentException>(() => m_database.Connection.GetSchema("MetaDataCollections", new[] { "xyzzy" }));
#endif

	[Theory]
	[InlineData("Databases")]
	[InlineData("DATABASES", "Databases")]
	[InlineData("DataTypes")]
	[InlineData("datatypes", "DataTypes")]
	[InlineData("Indexes")]
	[InlineData("IndexColumns")]
	//// only in 8.0 - [InlineData("KeyWords")]
	[InlineData("MetaDataCollections")]
	[InlineData("Procedures")]
	//// only in 8.0 - [InlineData("ResourceGroups")]
	[InlineData("Tables")]
	[InlineData("Triggers")]
	[InlineData("Views")]
#if !MYSQL_DATA
	[InlineData("CharacterSets")]
	[InlineData("CollationCharacterSetApplicability")]
	[InlineData("Collations")]
	[InlineData("Engines")]
	[InlineData("Foreign Keys")]
	[InlineData("KeyColumnUsage")]
	[InlineData("Parameters")]
	[InlineData("Partitions")]
	[InlineData("Plugins")]
	[InlineData("ProcessList")]
	[InlineData("Profiling")]
	[InlineData("ReferentialConstraints")]
	[InlineData("SchemaPrivileges")]
	[InlineData("TableConstraints")]
	[InlineData("TablePrivileges")]
	[InlineData("UserPrivileges")]
#endif
	public void GetSchema(string schemaName, string? expectedSchemaName = null)
	{
		var table = m_database.Connection.GetSchema(schemaName);
		Assert.NotNull(table);
		Assert.Equal(expectedSchemaName ?? schemaName, table.TableName);
	}

#if !MYSQL_DATA
	[Fact]
	public async Task GetMetaDataCollectionsSchemaAsync()
	{
		var table = await m_database.Connection.GetSchemaAsync();
		Assert.Equal(3, table.Columns.Count);
		Assert.Equal("CollectionName", table.Columns[0].ColumnName);
	}

	[Fact]
	public async Task GetCharacterSetsSchemaAsync()
	{
		var table = await m_database.Connection.GetSchemaAsync("CharacterSets");
		Assert.Equal(4, table.Columns.Count);
		Assert.Contains("latin1", table.Rows.Cast<DataRow>().Select(x => (string) x[0]));
		Assert.Contains("ascii", table.Rows.Cast<DataRow>().Select(x => (string) x[0]));
	}

	[Fact]
	public void GetCollationsSchema()
	{
		var table = m_database.Connection.GetSchema("Collations");
		Assert.Contains("latin1_general_ci", table.Rows.Cast<DataRow>().Select(x => (string) x[0]));
		Assert.Contains("ascii_bin", table.Rows.Cast<DataRow>().Select(x => (string) x[0]));
	}
#endif

	[Fact]
	public void ForeignKeys()
	{
		var schemaName = m_database.Connection.Database;
		var table = m_database.Connection.GetSchema("Foreign Keys", new[] { null, schemaName, "fk_test" });
		var row = table.Rows.Cast<DataRow>().Single();
		foreach (var (column, value) in new[]
		{
			("CONSTRAINT_CATALOG", "def"),
			("CONSTRAINT_SCHEMA", schemaName),
			("CONSTRAINT_NAME", "fk_test_fk"),
			("TABLE_CATALOG", "def"),
			("TABLE_SCHEMA", schemaName),
			("TABLE_NAME", "fk_test"),
			("MATCH_OPTION", "NONE"),
			("REFERENCED_TABLE_CATALOG", null),
			("REFERENCED_TABLE_SCHEMA", schemaName),
			("REFERENCED_TABLE_NAME", "pk_test"),
		})
		{
			Assert.Equal(value, row[column] is DBNull ? null : (string?) row[column]);
		}
	}

	[Fact]
	public void Indexes()
	{
		var schemaName = m_database.Connection.Database;
		var table = m_database.Connection.GetSchema("Indexes", new[] { null, schemaName, "pk_test" });
		var actual = table.Rows
			.Cast<DataRow>()
			.OrderBy(x => (string) x["INDEX_NAME"])
			.Select(x => ((string) x["INDEX_SCHEMA"], (string) x["INDEX_NAME"], (string) x["TABLE_NAME"], (bool) x["UNIQUE"], (bool) x["PRIMARY"], (string) x["TYPE"]));
		var expected = new[]
		{
			(schemaName, "pk_test_ix", "pk_test", false, false, "BTREE"),
			(schemaName, "pk_test_uq", "pk_test", true, false, "BTREE"),
			(schemaName, "PRIMARY", "pk_test", true, true, "BTREE"),
		};
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void IndexColumns()
	{
		var schemaName = m_database.Connection.Database;
		var table = m_database.Connection.GetSchema("IndexColumns", new[] { null, schemaName, "pk_test", "pk_test_uq" });
		var actual = table.Rows
			.Cast<DataRow>()
			.OrderBy(x => (string) x["INDEX_NAME"])
			.ThenBy(x => (int) x["ORDINAL_POSITION"])
			.Select(x => ((string) x["INDEX_SCHEMA"], (string) x["INDEX_NAME"], (string) x["TABLE_NAME"], (string) x["COLUMN_NAME"], (int) x["ORDINAL_POSITION"]));
		var expected = new[]
		{
			(schemaName, "pk_test_uq", "pk_test", "c", 1),
			(schemaName, "pk_test_uq", "pk_test", "d", 2),
			(schemaName, "pk_test_uq", "pk_test", "e", 3),
		};
		Assert.Equal(expected, actual);
	}

	[Fact]
	public void IndexColumnsWithColumnName()
	{
		var schemaName = m_database.Connection.Database;
		var table = m_database.Connection.GetSchema("IndexColumns", new[] { null, schemaName, "pk_test", "pk_test_uq", "d" });
		var actual = table.Rows
			.Cast<DataRow>()
			.OrderBy(x => (string) x["INDEX_NAME"])
			.ThenBy(x => (int) x["ORDINAL_POSITION"])
			.Select(x => ((string) x["INDEX_SCHEMA"], (string) x["INDEX_NAME"], (string) x["TABLE_NAME"], (string) x["COLUMN_NAME"], (int) x["ORDINAL_POSITION"]));
		var expected = new[]
		{
			(schemaName, "pk_test_uq", "pk_test", "d", 2),
		};
		Assert.Equal(expected, actual);
	}

	private readonly DatabaseFixture m_database;
}
