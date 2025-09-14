using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Domain.Models.Politics;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M005_CreateGroupSpendingPolicyTableMigration;

namespace Payka.Dal.Write.Configurations;

internal class GroupSpendingPolicyConfiguration : IEntityTypeConfiguration<GroupSpendingPolicy>
{
	public void Configure(EntityTypeBuilder<GroupSpendingPolicy> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.ApprovalRequired)
			.HasColumnName(ApprovalRequiredColumnName)
			.IsRequired();
		builder.Property(x => x.AllowTransfers)
			.HasColumnName(AllowTransfersColumnName)
			.IsRequired();

		builder.OwnsOne(x => x.ApprovalThreshold, money =>
		{
			money.Property(m => m.Amount)
				.HasColumnName(ApprovalThresholdAmountColumnName)
				.HasColumnType("decimal(19,4)");

			money.HasOne(m => m.Currency)
				.WithMany()
				.HasForeignKey(ApprovalThresholdCurrencyIdColumnName);
		});
	}
}