namespace MySqlConnector.Protocol;

/// <summary>
/// MySQL character set codes.
/// </summary>
/// <remarks>Obtained from <c>SELECT id, collation_name FROM information_schema.collations ORDER BY id;</c> on MySQL 8.0.30.</remarks>
internal enum CharacterSet : ushort
{
	None = 0,
	Big5ChineseCaseInsensitive = 1,
	Latin2CzechCaseSensitive = 2,
	Dec8SwedishCaseInsensitive = 3,
	Cp850GeneralCaseInsensitive = 4,
	Latin1German1CaseInsensitive = 5,
	Hp8EnglishCaseInsensitive = 6,
	Koi8rGeneralCaseInsensitive = 7,
	Latin1SwedishCaseInsensitive = 8,
	Latin2GeneralCaseInsensitive = 9,
	Swe7SwedishCaseInsensitive = 10,
	AsciiGeneralCaseInsensitive = 11,
	UjisJapaneseCaseInsensitive = 12,
	SjisJapaneseCaseInsensitive = 13,
	Cp1251BulgarianCaseInsensitive = 14,
	Latin1DanishCaseInsensitive = 15,
	HebrewGeneralCaseInsensitive = 16,
	Tis620ThaiCaseInsensitive = 18,
	EuckrKoreanCaseInsensitive = 19,
	Latin7EstonianCaseSensitive = 20,
	Latin2HungarianCaseInsensitive = 21,
	Koi8uGeneralCaseInsensitive = 22,
	Cp1251UkrainianCaseInsensitive = 23,
	Gb2312ChineseCaseInsensitive = 24,
	GreekGeneralCaseInsensitive = 25,
	Cp1250GeneralCaseInsensitive = 26,
	Latin2CroatianCaseInsensitive = 27,
	GbkChineseCaseInsensitive = 28,
	Cp1257LithuanianCaseInsensitive = 29,
	Latin5TurkishCaseInsensitive = 30,
	Latin1German2CaseInsensitive = 31,
	Armscii8GeneralCaseInsensitive = 32,
	Utf8Mb3GeneralCaseInsensitive = 33,
	Cp1250CzechCaseSensitive = 34,
	Ucs2GeneralCaseInsensitive = 35,
	Cp866GeneralCaseInsensitive = 36,
	Keybcs2GeneralCaseInsensitive = 37,
	MacceGeneralCaseInsensitive = 38,
	MacromanGeneralCaseInsensitive = 39,
	Cp852GeneralCaseInsensitive = 40,
	Latin7GeneralCaseInsensitive = 41,
	Latin7GeneralCaseSensitive = 42,
	MacceBinary = 43,
	Cp1250CroatianCaseInsensitive = 44,
	Utf8Mb4GeneralCaseInsensitive = 45,
	Utf8Mb4Binary = 46,
	Latin1Binary = 47,
	Latin1GeneralCaseInsensitive = 48,
	Latin1GeneralCaseSensitive = 49,
	Cp1251Binary = 50,
	Cp1251GeneralCaseInsensitive = 51,
	Cp1251GeneralCaseSensitive = 52,
	MacromanBinary = 53,
	Utf16GeneralCaseInsensitive = 54,
	Utf16Binary = 55,
	Utf16leGeneralCaseInsensitive = 56,
	Cp1256GeneralCaseInsensitive = 57,
	Cp1257Binary = 58,
	Cp1257GeneralCaseInsensitive = 59,
	Utf32GeneralCaseInsensitive = 60,
	Utf32Binary = 61,
	Utf16leBinary = 62,
	Binary = 63,
	Armscii8Binary = 64,
	AsciiBinary = 65,
	Cp1250Binary = 66,
	Cp1256Binary = 67,
	Cp866Binary = 68,
	Dec8Binary = 69,
	GreekBinary = 70,
	HebrewBinary = 71,
	Hp8Binary = 72,
	Keybcs2Binary = 73,
	Koi8rBinary = 74,
	Koi8uBinary = 75,
	Utf8Mb3ToLowerCaseInsensitive = 76,
	Latin2Binary = 77,
	Latin5Binary = 78,
	Latin7Binary = 79,
	Cp850Binary = 80,
	Cp852Binary = 81,
	Swe7Binary = 82,
	Utf8Mb3Binary = 83,
	Big5Binary = 84,
	EuckrBinary = 85,
	Gb2312Binary = 86,
	GbkBinary = 87,
	SjisBinary = 88,
	Tis620Binary = 89,
	Ucs2Binary = 90,
	UjisBinary = 91,
	Geostd8GeneralCaseInsensitive = 92,
	Geostd8Binary = 93,
	Latin1SpanishCaseInsensitive = 94,
	Cp932JapaneseCaseInsensitive = 95,
	Cp932Binary = 96,
	EucjpmsJapaneseCaseInsensitive = 97,
	EucjpmsBinary = 98,
	Cp1250PolishCaseInsensitive = 99,
	Utf16UnicodeCaseInsensitive = 101,
	Utf16IcelandicCaseInsensitive = 102,
	Utf16LatvianCaseInsensitive = 103,
	Utf16RomanianCaseInsensitive = 104,
	Utf16SlovenianCaseInsensitive = 105,
	Utf16PolishCaseInsensitive = 106,
	Utf16EstonianCaseInsensitive = 107,
	Utf16SpanishCaseInsensitive = 108,
	Utf16SwedishCaseInsensitive = 109,
	Utf16TurkishCaseInsensitive = 110,
	Utf16CzechCaseInsensitive = 111,
	Utf16DanishCaseInsensitive = 112,
	Utf16LithuanianCaseInsensitive = 113,
	Utf16SlovakCaseInsensitive = 114,
	Utf16Spanish2CaseInsensitive = 115,
	Utf16RomanCaseInsensitive = 116,
	Utf16PersianCaseInsensitive = 117,
	Utf16EsperantoCaseInsensitive = 118,
	Utf16HungarianCaseInsensitive = 119,
	Utf16SinhalaCaseInsensitive = 120,
	Utf16German2CaseInsensitive = 121,
	Utf16CroatianCaseInsensitive = 122,
	Utf16Unicode520CaseInsensitive = 123,
	Utf16VietnameseCaseInsensitive = 124,
	Ucs2UnicodeCaseInsensitive = 128,
	Ucs2IcelandicCaseInsensitive = 129,
	Ucs2LatvianCaseInsensitive = 130,
	Ucs2RomanianCaseInsensitive = 131,
	Ucs2SlovenianCaseInsensitive = 132,
	Ucs2PolishCaseInsensitive = 133,
	Ucs2EstonianCaseInsensitive = 134,
	Ucs2SpanishCaseInsensitive = 135,
	Ucs2SwedishCaseInsensitive = 136,
	Ucs2TurkishCaseInsensitive = 137,
	Ucs2CzechCaseInsensitive = 138,
	Ucs2DanishCaseInsensitive = 139,
	Ucs2LithuanianCaseInsensitive = 140,
	Ucs2SlovakCaseInsensitive = 141,
	Ucs2Spanish2CaseInsensitive = 142,
	Ucs2RomanCaseInsensitive = 143,
	Ucs2PersianCaseInsensitive = 144,
	Ucs2EsperantoCaseInsensitive = 145,
	Ucs2HungarianCaseInsensitive = 146,
	Ucs2SinhalaCaseInsensitive = 147,
	Ucs2German2CaseInsensitive = 148,
	Ucs2CroatianCaseInsensitive = 149,
	Ucs2Unicode520CaseInsensitive = 150,
	Ucs2VietnameseCaseInsensitive = 151,
	Ucs2GeneralMySql500CaseInsensitive = 159,
	Utf32UnicodeCaseInsensitive = 160,
	Utf32IcelandicCaseInsensitive = 161,
	Utf32LatvianCaseInsensitive = 162,
	Utf32RomanianCaseInsensitive = 163,
	Utf32SlovenianCaseInsensitive = 164,
	Utf32PolishCaseInsensitive = 165,
	Utf32EstonianCaseInsensitive = 166,
	Utf32SpanishCaseInsensitive = 167,
	Utf32SwedishCaseInsensitive = 168,
	Utf32TurkishCaseInsensitive = 169,
	Utf32CzechCaseInsensitive = 170,
	Utf32DanishCaseInsensitive = 171,
	Utf32LithuanianCaseInsensitive = 172,
	Utf32SlovakCaseInsensitive = 173,
	Utf32Spanish2CaseInsensitive = 174,
	Utf32RomanCaseInsensitive = 175,
	Utf32PersianCaseInsensitive = 176,
	Utf32EsperantoCaseInsensitive = 177,
	Utf32HungarianCaseInsensitive = 178,
	Utf32SinhalaCaseInsensitive = 179,
	Utf32German2CaseInsensitive = 180,
	Utf32CroatianCaseInsensitive = 181,
	Utf32Unicode520CaseInsensitive = 182,
	Utf32VietnameseCaseInsensitive = 183,
	Utf8Mb3UnicodeCaseInsensitive = 192,
	Utf8Mb3IcelandicCaseInsensitive = 193,
	Utf8Mb3LatvianCaseInsensitive = 194,
	Utf8Mb3RomanianCaseInsensitive = 195,
	Utf8Mb3SlovenianCaseInsensitive = 196,
	Utf8Mb3PolishCaseInsensitive = 197,
	Utf8Mb3EstonianCaseInsensitive = 198,
	Utf8Mb3SpanishCaseInsensitive = 199,
	Utf8Mb3SwedishCaseInsensitive = 200,
	Utf8Mb3TurkishCaseInsensitive = 201,
	Utf8Mb3CzechCaseInsensitive = 202,
	Utf8Mb3DanishCaseInsensitive = 203,
	Utf8Mb3LithuanianCaseInsensitive = 204,
	Utf8Mb3SlovakCaseInsensitive = 205,
	Utf8Mb3Spanish2CaseInsensitive = 206,
	Utf8Mb3RomanCaseInsensitive = 207,
	Utf8Mb3PersianCaseInsensitive = 208,
	Utf8Mb3EsperantoCaseInsensitive = 209,
	Utf8Mb3HungarianCaseInsensitive = 210,
	Utf8Mb3SinhalaCaseInsensitive = 211,
	Utf8Mb3German2CaseInsensitive = 212,
	Utf8Mb3CroatianCaseInsensitive = 213,
	Utf8Mb3Unicode520CaseInsensitive = 214,
	Utf8Mb3VietnameseCaseInsensitive = 215,
	Utf8Mb3GeneralMySql500CaseInsensitive = 223,
	Utf8Mb4UnicodeCaseInsensitive = 224,
	Utf8Mb4IcelandicCaseInsensitive = 225,
	Utf8Mb4LatvianCaseInsensitive = 226,
	Utf8Mb4RomanianCaseInsensitive = 227,
	Utf8Mb4SlovenianCaseInsensitive = 228,
	Utf8Mb4PolishCaseInsensitive = 229,
	Utf8Mb4EstonianCaseInsensitive = 230,
	Utf8Mb4SpanishCaseInsensitive = 231,
	Utf8Mb4SwedishCaseInsensitive = 232,
	Utf8Mb4TurkishCaseInsensitive = 233,
	Utf8Mb4CzechCaseInsensitive = 234,
	Utf8Mb4DanishCaseInsensitive = 235,
	Utf8Mb4LithuanianCaseInsensitive = 236,
	Utf8Mb4SlovakCaseInsensitive = 237,
	Utf8Mb4Spanish2CaseInsensitive = 238,
	Utf8Mb4RomanCaseInsensitive = 239,
	Utf8Mb4PersianCaseInsensitive = 240,
	Utf8Mb4EsperantoCaseInsensitive = 241,
	Utf8Mb4HungarianCaseInsensitive = 242,
	Utf8Mb4SinhalaCaseInsensitive = 243,
	Utf8Mb4German2CaseInsensitive = 244,
	Utf8Mb4CroatianCaseInsensitive = 245,
	Utf8Mb4Unicode520CaseInsensitive = 246,
	Utf8Mb4VietnameseCaseInsensitive = 247,
	Gb18030ChineseCaseInsensitive = 248,
	Gb18030Binary = 249,
	Gb18030Unicode520CaseInsensitive = 250,
	Utf8Mb4Uca900AccentInsensitiveCaseInsensitive = 255,
	Utf8Mb4GermanPhonebookUca900AccentInsensitiveCaseInsensitive = 256,
	Utf8Mb4IcelandicUca900AccentInsensitiveCaseInsensitive = 257,
	Utf8Mb4LatvianUca900AccentInsensitiveCaseInsensitive = 258,
	Utf8Mb4RomanianUca900AccentInsensitiveCaseInsensitive = 259,
	Utf8Mb4SlovenianUca900AccentInsensitiveCaseInsensitive = 260,
	Utf8Mb4PolishUca900AccentInsensitiveCaseInsensitive = 261,
	Utf8Mb4EstonianUca900AccentInsensitiveCaseInsensitive = 262,
	Utf8Mb4SpanishUca900AccentInsensitiveCaseInsensitive = 263,
	Utf8Mb4SwedishUca900AccentInsensitiveCaseInsensitive = 264,
	Utf8Mb4TurkishUca900AccentInsensitiveCaseInsensitive = 265,
	Utf8Mb4CaseSensitiveUca900AccentInsensitiveCaseInsensitive = 266,
	Utf8Mb4DanishUca900AccentInsensitiveCaseInsensitive = 267,
	Utf8Mb4LithuanianUca900AccentInsensitiveCaseInsensitive = 268,
	Utf8Mb4SlovakUca900AccentInsensitiveCaseInsensitive = 269,
	Utf8Mb4TraditionalSpanishUca900AccentInsensitiveCaseInsensitive = 270,
	Utf8Mb4LatinUca900AccentInsensitiveCaseInsensitive = 271,
	Utf8Mb4EsperantoUca900AccentInsensitiveCaseInsensitive = 273,
	Utf8Mb4HungarianUca900AccentInsensitiveCaseInsensitive = 274,
	Utf8Mb4CroatianUca900AccentInsensitiveCaseInsensitive = 275,
	Utf8Mb4VietnameseUca900AccentInsensitiveCaseInsensitive = 277,
	Utf8Mb4Uca900AccentSensitiveCaseSensitive = 278,
	Utf8Mb4GermanPhonebookUca900AccentSensitiveCaseSensitive = 279,
	Utf8Mb4IcelandicUca900AccentSensitiveCaseSensitive = 280,
	Utf8Mb4LatvianUca900AccentSensitiveCaseSensitive = 281,
	Utf8Mb4RomanianUca900AccentSensitiveCaseSensitive = 282,
	Utf8Mb4SlovenianUca900AccentSensitiveCaseSensitive = 283,
	Utf8Mb4PolishUca900AccentSensitiveCaseSensitive = 284,
	Utf8Mb4EstonianUca900AccentSensitiveCaseSensitive = 285,
	Utf8Mb4SpanishUca900AccentSensitiveCaseSensitive = 286,
	Utf8Mb4SwedishUca900AccentSensitiveCaseSensitive = 287,
	Utf8Mb4TurkishUca900AccentSensitiveCaseSensitive = 288,
	Utf8Mb4CaseSensitiveUca900AccentSensitiveCaseSensitive = 289,
	Utf8Mb4DanishUca900AccentSensitiveCaseSensitive = 290,
	Utf8Mb4LithuanianUca900AccentSensitiveCaseSensitive = 291,
	Utf8Mb4SlovakUca900AccentSensitiveCaseSensitive = 292,
	Utf8Mb4TraditionalSpanishUca900AccentSensitiveCaseSensitive = 293,
	Utf8Mb4LatinUca900AccentSensitiveCaseSensitive = 294,
	Utf8Mb4EsperantoUca900AccentSensitiveCaseSensitive = 296,
	Utf8Mb4HungarianUca900AccentSensitiveCaseSensitive = 297,
	Utf8Mb4CroatianUca900AccentSensitiveCaseSensitive = 298,
	Utf8Mb4VietnameseUca900AccentSensitiveCaseSensitive = 300,
	Utf8Mb4JapaneseUca900AccentSensitiveCaseSensitive = 303,
	Utf8Mb4JapaneseUca900AccentSensitiveCaseSensitiveKanaSensitive = 304,
	Utf8Mb4Uca900AccentSensitiveCaseInsensitive = 305,
	Utf8Mb4RussianUca900AccentInsensitiveCaseInsensitive = 306,
	Utf8Mb4RussianUca900AccentSensitiveCaseSensitive = 307,
	Utf8Mb4ChineseUca900AccentSensitiveCaseSensitive = 308,
	Utf8Mb4Uca900Binary = 309,
	Utf8Mb4NorwegianBokmal0900AccentInsensitiveCaseInsensitive = 310,
	Utf8Mb4NorwegianBokmal0900AccentSensitiveCaseSensitive = 311,
	Utf8Mb4NorwegianNynorsk0900AccentInsensitiveCaseInsensitive = 312,
	Utf8Mb4NorwegianNynorsk0900AccentSensitiveCaseSensitive = 313,
	Utf8Mb4SerbianLatin0900AccentInsensitiveCaseInsensitive = 314,
	Utf8Mb4SerbianLatin0900AccentSensitiveCaseSensitive = 315,
	Utf8Mb4Bosnian0900AccentInsensitiveCaseInsensitive = 316,
	Utf8Mb4Bosnian0900AccentSensitiveCaseSensitive = 317,
	Utf8Mb4Bulgarian0900AccentInsensitiveCaseInsensitive = 318,
	Utf8Mb4Bulgarian0900AccentSensitiveCaseSensitive = 319,
	Utf8Mb4Galician0900AccentInsensitiveCaseInsensitive = 320,
	Utf8Mb4Galician0900AccentSensitiveCaseSensitive = 321,
	Utf8Mb4MongolianCyrillic0900AccentInsensitiveCaseInsensitive = 322,
	Utf8Mb4MongolianCyrillic0900AccentSensitiveCaseSensitive = 323,
	Utf8Mb3CroatianCaseInsensitiveMariaDb = 576,
	Utf8Mb3MyanmarCaseInsensitive = 577,
	Utf8Mb3ThaiUnicode520Weight2 = 578,
	Utf8Mb3General1400AccentSensitiveCaseInsensitive = 579,
	Utf8Mb4CroatianCaseInsensitiveMariaDb = 608,
	Utf8Mb4MyanmarCaseInsensitive = 609,
	Utf8Mb4ThaiUnicode520Weight2 = 610,
	Utf8Mb4General1400AccentSensitiveCaseInsensitive = 611,
	Ucs2CroatianCaseInsensitiveMariaDb = 640,
	Ucs2MyanmarCaseInsensitive = 641,
	Ucs2ThaiUnicode520Weight2 = 642,
	Utf16CroatianCaseInsensitiveMariaDb = 672,
	Utf16MyanmarCaseInsensitive = 673,
	Utf16ThaiUnicode520Weight2 = 674,
	Utf32CroatianCaseInsensitiveMariaDb = 736,
	Utf32MyanmarCaseInsensitive = 737,
	Utf32ThaiUnicode520Weight2 = 738,
	Big5ChineseNoPadCaseInsensitive = 1025,
	Dec8SwedishNoPadCaseInsensitive = 1027,
	Cp850GeneralNoPadCaseInsensitive = 1028,
	Hp8EnglishNoPadCaseInsensitive = 1030,
	Koi8rGeneralNoPadCaseInsensitive = 1031,
	Latin1SwedishNoPadCaseInsensitive = 1032,
	Latin2GeneralNoPadCaseInsensitive = 1033,
	Swe7SwedishNoPadCaseInsensitive = 1034,
	AsciiGeneralNoPadCaseInsensitive = 1035,
	UjisJapaneseNoPadCaseInsensitive = 1036,
	SjisJapaneseNoPadCaseInsensitive = 1037,
	HebrewGeneralNoPadCaseInsensitive = 1040,
	Tis620ThaiNoPadCaseInsensitive = 1042,
	EuckrKoreanNoPadCaseInsensitive = 1043,
	Koi8uGeneralNoPadCaseInsensitive = 1046,
	Gb2312ChineseNoPadCaseInsensitive = 1048,
	GreekGeneralNoPadCaseInsensitive = 1049,
	Cp1250GeneralNoPadCaseInsensitive = 1050,
	GbkChineseNoPadCaseInsensitive = 1052,
	Latin5TurkishNoPadCaseInsensitive = 1054,
	Armscii8GeneralNoPadCaseInsensitive = 1056,
	Utf8Mb3GeneralNoPadCaseInsensitive = 1057,
	Ucs2GeneralNoPadCaseInsensitive = 1059,
	Cp866GeneralNoPadCaseInsensitive = 1060,
	Keybcs2GeneralNoPadCaseInsensitive = 1061,
	MacCentralEuropeanGeneralNoPadCaseInsensitive = 1062,
	MacRomanGeneralNoPadCaseInsensitive = 1063,
	Cp852GeneralNoPadCaseInsensitive = 1064,
	Latin7GeneralNoPadCaseInsensitive = 1065,
	MacCentralEuropeanNoPadBinary = 1067,
	Utf8Mb4GeneralNoPadCaseInsensitive = 1069,
	Utf8Mb4NoPadBinary = 1070,
	Latin1NoPadBinary = 1071,
	Cp1251NoPadBinary = 1074,
	Cp1251GeneralNoPadCaseInsensitive = 1075,
	MacRomanNoPadBinary = 1077,
	Utf16GeneralNoPadCaseInsensitive = 1078,
	Utf16NoPadBinary = 1079,
	Utf16leGeneralNoPadCaseInsensitive = 1080,
	Cp1256GeneralNoPadCaseInsensitive = 1081,
	Cp1257NoPadBinary = 1082,
	Cp1257GeneralNoPadCaseInsensitive = 1083,
	Utf32GeneralNoPadCaseInsensitive = 1084,
	Utf32NoPadBinary = 1085,
	Utf16leNoPadBinary = 1086,
	Armscii8NoPadBinary = 1088,
	AsciiNoPadBinary = 1089,
	Cp1250NoPadBinary = 1090,
	Cp1256NoPadBinary = 1091,
	Cp866NoPadBinary = 1092,
	Dec8NoPadBinary = 1093,
	GreekNoPadBinary = 1094,
	HebrewNoPadBinary = 1095,
	Hp8NoPadBinary = 1096,
	Keybcs2NoPadBinary = 1097,
	Koi8rNoPadBinary = 1098,
	Koi8uNoPadBinary = 1099,
	Latin2NoPadBinary = 1101,
	Latin5NoPadBinary = 1102,
	Latin7NoPadBinary = 1103,
	Cp850NoPadBinary = 1104,
	Cp852NoPadBinary = 1105,
	Swe7NoPadBinary = 1106,
	Utf8Mb3NoPadBinary = 1107,
	Big5NoPadBinary = 1108,
	EuckrNoPadBinary = 1109,
	Gb2312NoPadBinary = 1110,
	GbkNoPadBinary = 1111,
	SjisNoPadBinary = 1112,
	Tis620NoPadBinary = 1113,
	Ucs2NoPadBinary = 1114,
	UjisNoPadBinary = 1115,
	Geostd8GeneralNoPadCaseInsensitive = 1116,
	Geostd8NoPadBinary = 1117,
	Cp932JapaneseNoPadCaseInsensitive = 1119,
	Cp932NoPadBinary = 1120,
	EucjpmsJapaneseNoPadCaseInsensitive = 1121,
	EucjpmsNoPadBinary = 1122,
	Utf16UnicodeNoPadCaseInsensitive = 1125,
	Utf16Unicode520NoPadCaseInsensitive = 1147,
	Ucs2UnicodeNoPadCaseInsensitive = 1152,
	Ucs2Unicode520NoPadCaseInsensitive = 1174,
	Utf32UnicodeNoPadCaseInsensitive = 1184,
	Utf32Unicode520NoPadCaseInsensitive = 1206,
	Utf8Mb3UnicodeNoPadCaseInsensitive = 1216,
	Utf8Mb3Unicode520NoPadCaseInsensitive = 1238,
	Utf8Mb4UnicodeNoPadCaseInsensitive = 1248,
	Utf8Mb4Unicode520NoPadCaseInsensitive = 1270,
}
