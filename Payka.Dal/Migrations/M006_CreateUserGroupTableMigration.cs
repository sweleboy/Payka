using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(6)]
public class M006_CreateUserGroupTableMigration : Migration
{
	public const string TableName = "user_groups";
	public const string NameColumnName = "name";
	public const string OwnerIdColumnName = "owner_id";
	public const string SpendingPolicyIdColumnName = "spending_policy_id";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(NameColumnName).AsString(128).NotNullable()
			.WithColumn(OwnerIdColumnName).AsGuid().NotNullable()
			.WithColumn(SpendingPolicyIdColumnName).AsGuid().Nullable();

		Create.ForeignKey("fk_group_owner_user")
			.FromTable(TableName).ForeignColumn(OwnerIdColumnName)
			.ToTable(M001_CreateUserTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.ForeignKey("fk_group_owner_user").OnTable(TableName);
		Delete.ForeignKey("fk_group_spending_policy").OnTable(TableName);
		Delete.Table(TableName);
	}
}
