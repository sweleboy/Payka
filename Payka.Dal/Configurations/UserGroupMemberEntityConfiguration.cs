using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payka.Dal.Migrations;
using Payka.ReadModel.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M007_CreateUserGroupMemberTableMigration;

namespace Payka.Dal.Configurations;

public class UserGroupMemberEntityConfiguration : IEntityTypeConfiguration<UserGroupMemberEntity>
{
	public void Configure(EntityTypeBuilder<UserGroupMemberEntity> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.CreateDate)
			.HasColumnName(CreatedDateColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.Role)
			.HasColumnName(RoleColumnName)
			.HasConversion<EnumToStringConverter<UserGroupRole>>()
			.IsRequired();

		builder.HasOne<UserGroupEntity>()
			.WithMany(g => g.Members)
			.HasForeignKey(GroupIdColumnName);

		builder.HasOne(x => x.User)
			.WithMany()
			.HasForeignKey(UserIdColumnName);

		builder.Navigation(x => x.User)
			.AutoInclude();
	}
}