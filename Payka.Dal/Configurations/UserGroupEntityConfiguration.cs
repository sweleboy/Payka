using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payka.Dal.Migrations;
using Payka.ReadModel.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M006_CreateUserGroupTableMigration;
using static Payka.Dal.Migrations.M009_CreateUserGroupWalletsTableMigration;

namespace Payka.Dal.Configurations;

public class UserGroupEntityConfiguration : IEntityTypeConfiguration<UserGroupEntity>
{
	public void Configure(EntityTypeBuilder<UserGroupEntity> builder)
{
	builder.ToTable(M006_CreateUserGroupTableMigration.TableName);
	builder.HasKey(x => x.Id);

	builder.Property(x => x.Id)
		.HasColumnName(IdColumnName);
	builder.Property(x => x.CreateDate)
		.HasColumnName(CreatedDateColumnName);
	builder.Property(x => x.IsDeleted)
		.HasColumnName(IsDeleteColumnName);

	builder.Property(x => x.Name)
		.HasColumnName(NameColumnName)
		.HasMaxLength(128)
		.IsRequired();

	builder.HasOne(x => x.Owner)
		.WithMany()
		.HasForeignKey(OwnerIdColumnName);

	builder.HasOne(x => x.SpendingPolicy)
		.WithMany()
		.HasForeignKey(SpendingPolicyIdColumnName);

	builder.Navigation(x => x.Owner)
		.AutoInclude();
	builder.Navigation(x => x.Members)
		.AutoInclude();
	builder.Navigation(x => x.GroupWallets)
		.AutoInclude();
}
}