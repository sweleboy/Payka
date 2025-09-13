using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(9)]
public class M009_CreateUserGroupWalletsTableMigration : Migration
{
	public const string TableName = "group_wallets";
	public const string GroupIdColumnName = "group_id";
	public const string WalletIdColumnName = "wallet_id";
	public const string AliasColumnName = "alias";
	public const string StatusColumnName = "status";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(GroupIdColumnName).AsGuid().NotNullable()
			.WithColumn(WalletIdColumnName).AsGuid().NotNullable()
			.WithColumn(AliasColumnName).AsString(128).Nullable()
			.WithColumn(StatusColumnName).AsInt32().NotNullable().WithDefaultValue(0);

		Create.ForeignKey("fk_group_wallet_group")
			.FromTable(TableName).ForeignColumn(GroupIdColumnName)
			.ToTable(M006_CreateUserGroupTableMigration.TableName).PrimaryColumn(IdColumnName);

		Create.ForeignKey("fk_group_wallet_wallet")
			.FromTable(TableName).ForeignColumn(WalletIdColumnName)
			.ToTable(M004_CreateWalletTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.ForeignKey("fk_group_wallet_group").OnTable(TableName);
		Delete.ForeignKey("fk_group_wallet_wallet").OnTable(TableName);
		Delete.Table(TableName);
	}
}