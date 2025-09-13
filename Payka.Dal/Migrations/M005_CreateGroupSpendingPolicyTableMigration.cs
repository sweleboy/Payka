using FluentMigrator;
using Payka.Dal.Extensions;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Migrations;

[Migration(5)]
public class M005_CreateGroupSpendingPolicyTableMigration : Migration
{
	public const string TableName = "group_spending_policies";
	public const string ApprovalRequiredColumnName = "approval_required";
	public const string ApprovalThresholdAmountColumnName = "approval_threshold_amount";
	public const string ApprovalThresholdCurrencyIdColumnName = "approval_threshold_currency_id";
	public const string AllowTransfersColumnName = "allow_transfers";

	public override void Up()
	{
		Create.Table(TableName)
			.WithColumn(IdColumnName).AsGuid().PrimaryKey().NotNullable()
			.AddBaseReadModelAudit()
			.WithColumn(ApprovalRequiredColumnName).AsBoolean().NotNullable().WithDefaultValue(false)
			.WithColumn(ApprovalThresholdAmountColumnName).AsDecimal(19, 4).Nullable()
			.WithColumn(ApprovalThresholdCurrencyIdColumnName).AsGuid().Nullable()
			.WithColumn(AllowTransfersColumnName).AsBoolean().NotNullable().WithDefaultValue(true);

		Create.ForeignKey("fk_policy_threshold_currency")
			.FromTable(TableName).ForeignColumn(ApprovalThresholdCurrencyIdColumnName)
			.ToTable(M003_CreateCurrencyTableMigration.TableName).PrimaryColumn(IdColumnName);
	}

	public override void Down()
	{
		Delete.ForeignKey("fk_policy_threshold_currency").OnTable(TableName);
		Delete.Table(TableName);
	}
}
