using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Dal.Migrations;
using Payka.ReadModel.Models;
using Payka.ReadModel.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M004_CreateWalletTableMigration;
using static Payka.Dal.Migrations.M006_CreateUserGroupTableMigration;
using static Payka.Dal.Migrations.M009_CreateUserGroupWalletsTableMigration;

namespace Payka.Dal.Configurations;

public class GroupWalletEntityConfiguration : IEntityTypeConfiguration<GroupWalletEntity>
{
	public void Configure(EntityTypeBuilder<GroupWalletEntity> builder)
	{
		builder.ToTable(M009_CreateUserGroupWalletsTableMigration.TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property<Guid>("WalletId")
			.HasColumnName(WalletIdColumnName);

		builder.HasOne<UserGroupEntity>()
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
