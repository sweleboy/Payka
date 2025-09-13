using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(7)]
public class M007_CreateUserGroupMemberTableMigration : Migration
{
	public const string TableName = "user_group_members";
	public const string GroupIdColumnName = "group_id";
	public const string UserIdColumnName = "user_id";
	public const string RoleColumnName = "role";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(GroupIdColumnName).AsGuid().NotNullable()
			.WithColumn(UserIdColumnName).AsGuid().NotNullable()
			.WithColumn(RoleColumnName).AsString().NotNullable();

		Create.ForeignKey("fk_group_member_group")
			.FromTable(TableName).ForeignColumn(GroupIdColumnName)
			.ToTable(M006_CreateUserGroupTableMigration.TableName).PrimaryColumn(IdColumnName);

		Create.ForeignKey("fk_group_member_user")
			.FromTable(TableName).ForeignColumn(UserIdColumnName)
			.ToTable(M001_CreateUserTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.ForeignKey("fk_group_member_group").OnTable(TableName);
		Delete.ForeignKey("fk_group_member_user").OnTable(TableName);
		Delete.Table(TableName);
	}
}
