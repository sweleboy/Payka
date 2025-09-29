using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(2)]
public class M002_CreateCategoryTableMigration : Migration
{
	public const string TableName = "categories";
	public const string NameColumnName = "name";
	public const string OwnerIdColumnName = "owner_id";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(NameColumnName).AsString(128).NotNullable()
			.WithColumn(OwnerIdColumnName).AsGuid().NotNullable();

		Create.ForeignKey("fk_category_owner_user")
			.FromTable(TableName).ForeignColumn(OwnerIdColumnName)
			.ToTable(M001_CreateUserTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.Table(TableName);
	}
}