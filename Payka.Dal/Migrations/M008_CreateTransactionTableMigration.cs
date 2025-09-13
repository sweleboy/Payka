using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(8)]
public class M008_CreateTransactionTableMigration : Migration
{
	public const string TableName = "transactions";
	public const string AmountAmountColumnName = "amount_amount";
	public const string AmountCurrencyIdColumnName = "amount_currency_id";
	public const string TypeColumnName = "type";
	public const string WalletIdColumnName = "wallet_id";
	public const string InitiatorIdColumnName = "initiator_id";
	public const string CategoryIdColumnName = "category_id";
	public const string DescriptionColumnName = "description";
	public const string OccurredDateColumnName = "occurred_date";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(AmountAmountColumnName).AsDecimal(19, 4).NotNullable()
			.WithColumn(AmountCurrencyIdColumnName).AsGuid().NotNullable()
			.WithColumn(TypeColumnName).AsInt32().NotNullable()
			.WithColumn(WalletIdColumnName).AsGuid().NotNullable()
			.WithColumn(InitiatorIdColumnName).AsGuid().NotNullable()
			.WithColumn(CategoryIdColumnName).AsGuid().NotNullable()
			.WithColumn(DescriptionColumnName).AsString(1024).Nullable()
			.WithColumn(OccurredDateColumnName).AsDateTimeOffset().NotNullable();

		Create.ForeignKey("fk_tx_currency")
			.FromTable(TableName).ForeignColumn(AmountCurrencyIdColumnName)
			.ToTable(M003_CreateCurrencyTableMigration.TableName).PrimaryColumn(IdColumnName);

		Create.ForeignKey("fk_tx_wallet")
			.FromTable(TableName).ForeignColumn(WalletIdColumnName)
			.ToTable(M004_CreateWalletTableMigration.TableName).PrimaryColumn(IdColumnName);

		Create.ForeignKey("fk_tx_initiator")
			.FromTable(TableName).ForeignColumn(InitiatorIdColumnName)
			.ToTable(M001_CreateUserTableMigration.TableName).PrimaryColumn(IdColumnName);

		Create.ForeignKey("fk_tx_category")
			.FromTable(TableName).ForeignColumn(CategoryIdColumnName)
			.ToTable(M002_CreateCategoryTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.ForeignKey("fk_tx_currency").OnTable(TableName);
		Delete.ForeignKey("fk_tx_wallet").OnTable(TableName);
		Delete.ForeignKey("fk_tx_initiator").OnTable(TableName);
		Delete.ForeignKey("fk_tx_category").OnTable(TableName);
		Delete.Table(TableName);
	}
}
