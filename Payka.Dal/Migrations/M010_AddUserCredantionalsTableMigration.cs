using FluentMigrator;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(10)]
public class M010_AddUserCredantionalsTableMigration : Migration
{
	public const string TableName = "users_credantionals";
	public const string UserIdColumnName = "user_id";
	public const string UserNameColumnName = "user_name";
	public const string PasswordColumnName = "password";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(UserIdColumnName).AsGuid().ForeignKey(M001_CreateUserTableMigration.TableName, IdColumnName)
			.WithColumn(UserNameColumnName).AsString().NotNullable()
			.WithColumn(PasswordColumnName).AsString().NotNullable();
	}

	public override void Down()
	{
		Delete.Table(TableName);
	}
}