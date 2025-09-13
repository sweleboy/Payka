using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(1)]
public class M001_CreateUserTableMigration : Migration
{
	public const string TableName = "users";
	public const string UserNameColumnName = "user_name";
	public const string FullNameColumnName = "full_name";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(UserNameColumnName).AsString(128).NotNullable()
			.WithColumn(FullNameColumnName).AsString(256).NotNullable();
	}

	public override void Down()
	{
		Delete.Table(TableName);
	}
}