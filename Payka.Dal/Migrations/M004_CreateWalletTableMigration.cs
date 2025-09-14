using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations
{
	[Migration(4)]
	public class M004_CreateWalletTableMigration : Migration
	{
		public const string TableName = "wallets";
		public const string NameColumnName = "name";
		public const string NotesColumnName = "notes";
		public const string OwnerIdColumnName = "owner_id";
		public const string BalanceAmountColumnName = "balance_amount";
		public const string BalanceCurrencyIdColumnName = "balance_currency_id";
		public const string IsGoupWalletColumnName = "is_group_wallet";

		public override void Up()
		{
			Create.Table(TableName)
				.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
				.AddBaseReadModelAudit()
				.WithColumn(NameColumnName).AsString(128).NotNullable()
				.WithColumn(NotesColumnName).AsString(1024).Nullable()
				.WithColumn(OwnerIdColumnName).AsGuid().NotNullable()
				.WithColumn(BalanceAmountColumnName).AsDecimal(19, 4).NotNullable()
				.WithColumn(BalanceCurrencyIdColumnName).AsGuid().NotNullable()
				.WithColumn(IsGoupWalletColumnName).AsBoolean().NotNullable().WithDefaultValue(false);

			Create.ForeignKey("fk_wallet_owner_user")
				.FromTable(TableName).ForeignColumn(OwnerIdColumnName)
				.ToTable(M001_CreateUserTableMigration.TableName).PrimaryColumn(IdColumnName);

			Create.ForeignKey("fk_wallet_balance_currency")
				.FromTable(TableName).ForeignColumn(BalanceCurrencyIdColumnName)
				.ToTable(M003_CreateCurrencyTableMigration.TableName).PrimaryColumn(IdColumnName);
		}

		public override void Down()
		{
			Delete.ForeignKey("fk_wallet_owner_user").OnTable(TableName);
			Delete.ForeignKey("fk_wallet_balance_currency").OnTable(TableName);
			Delete.Table(TableName);
		}
	}
}
