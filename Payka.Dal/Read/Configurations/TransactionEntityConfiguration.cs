using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payka.ReadModel.Models.Transactions;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M008_CreateTransactionTableMigration;

namespace Payka.Dal.Read.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
	public void Configure(EntityTypeBuilder<TransactionEntity> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.CreateDate)
			.HasColumnName(CreatedDateColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.Type)
			.HasColumnName(TypeColumnName)
			.HasConversion<EnumToStringConverter<TransactionType>>()
			.IsRequired();
		builder.Property(x => x.Description)
			.HasColumnName(DescriptionColumnName)
			.HasMaxLength(1024);
		builder.Property(x => x.OccurredDate)
			.HasColumnName(OccurredDateColumnName);

		builder.OwnsOne(x => x.Amount, money =>
		{
			money.Property(m => m.Amount)
				 .HasColumnName(AmountAmountColumnName)
				 .HasColumnType("decimal(19,4)")
				 .IsRequired();

			money.HasOne(m => m.Currency)
				 .WithMany()
				 .HasForeignKey(AmountCurrencyIdColumnName);
		});

		builder.HasOne(x => x.Wallet)
		 .WithMany()
		 .HasForeignKey(WalletIdColumnName);

		builder.HasOne(x => x.Initiator)
		 .WithMany()
		 .HasForeignKey(InitiatorIdColumnName);

		builder.HasOne(x => x.Category)
		 .WithMany()
		 .HasForeignKey(CategoryIdColumnName);

		builder.Navigation(x => x.Wallet)
			.AutoInclude();
		builder.Navigation(x => x.Initiator)
			.AutoInclude();
		builder.Navigation(x => x.Category)
			.AutoInclude();
	}
}