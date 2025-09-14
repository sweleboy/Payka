using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Domain.Models.Common;
using Payka.Domain.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M009_CreateUserGroupWalletsTableMigration;

namespace Payka.Dal.Write.Configurations;

public class GroupWalletConfiguration : IEntityTypeConfiguration<GroupWallet>
{
	public void Configure(EntityTypeBuilder<GroupWallet> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property<Guid>("WalletId")
			.HasColumnName(WalletIdColumnName);

		builder.HasOne<UserGroup>()
			.WithMany(g => g.GroupWallets)
			.HasForeignKey(GroupIdColumnName);

		builder.HasOne(x => x.Wallet)
			.WithMany()
			.HasForeignKey("WalletId")
			.HasConstraintName("fk_group_wallet_wallet");

		builder.Navigation(x => x.Wallet)
			.AutoInclude();
	}
}