using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(2)]
public class M002_CreateCategoryTableMigration : Migration
{
	public const string TableName = "categories";
	public const string NameColumnName = "name";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(NameColumnName).AsString(128).NotNullable();
	}

	public override void Down()
	{
		Delete.Table(TableName);
	}
}