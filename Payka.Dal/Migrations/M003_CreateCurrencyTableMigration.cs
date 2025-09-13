using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(3)]
public class M003_CreateCurrencyTableMigration : Migration
{
	public const string TableName = "currencies";
	public const string CodeColumnName = "code";
	public const string SymbolColumnName = "symbol";
	public const string RublesValueColumnName = "rubles_value";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(CodeColumnName).AsString(8).NotNullable()
			.WithColumn(SymbolColumnName).AsString(8).Nullable()
			.WithColumn(RublesValueColumnName).AsDecimal(19, 6).NotNullable();
	}

	public override void Down()
	{
		Delete.Table(TableName);
	}
}