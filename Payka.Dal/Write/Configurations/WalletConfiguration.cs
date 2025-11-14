using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Domain.Models.Wallets;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M004_CreateWalletTableMigration;

namespace Payka.Dal.Write.Configurations;

internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
	public void Configure(EntityTypeBuilder<Wallet> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.Name)
			.HasColumnName(NameColumnName)
			.HasMaxLength(128)
			.IsRequired();
		builder.Property(x => x.Notes)
			.HasColumnName(NotesColumnName)
			.HasMaxLength(1024);

		builder.Property(x => x.IsGroupWallet)
			.HasColumnName(IsGoupWalletColumnName)
			.IsRequired();

		builder.HasOne(x => x.Owner)
			.WithMany()
			.HasForeignKey(OwnerIdColumnName);

		builder.OwnsOne(x => x.Balance, money =>
		{
			money.Property(m => m.Amount)
				 .HasColumnName(BalanceAmountColumnName)
				 .HasColumnType("decimal(19,4)")
				 .IsRequired();

			money.Property<Guid>("CurrencyId")
				 .HasColumnName(BalanceCurrencyIdColumnName)
				 .IsRequired();

			money.HasOne(m => m.Currency)
				 .WithMany()
				 .HasForeignKey("CurrencyId");

			money.Navigation(m => m.Currency)
			.AutoInclude();
		});

		builder.Navigation(x => x.Owner)
			.AutoInclude();
		builder.OwnsOne(x => x.Balance)
			.Navigation(m => m.Currency)
			.AutoInclude();
	}
}
