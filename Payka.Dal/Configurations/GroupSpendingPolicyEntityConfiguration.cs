using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.ReadModel.Models;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M005_CreateGroupSpendingPolicyTableMigration;

namespace Payka.Dal.Configurations;

public class GroupSpendingPolicyEntityConfiguration : IEntityTypeConfiguration<GroupSpendingPolicyEntity>
{
	public void Configure(EntityTypeBuilder<GroupSpendingPolicyEntity> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.CreateDate)
			.HasColumnName(CreatedDateColumnName);
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