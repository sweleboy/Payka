using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payka.Domain.Models;
using Payka.Domain.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M007_CreateUserGroupMemberTableMigration;

namespace Payka.Dal.Write.Configurations;

internal class UserGroupMemberConfiguration : IEntityTypeConfiguration<UserGroupMember>
{
	public void Configure(EntityTypeBuilder<UserGroupMember> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.Role)
			.HasColumnName(RoleColumnName)
			.HasConversion<EnumToStringConverter<UserGroupRole>>()
			.IsRequired();

		builder.HasOne<UserGroup>()
			.WithMany(g => g.Members)
			.HasForeignKey(GroupIdColumnName);

		builder.HasOne(x => x.User)
			.WithMany()
			.HasForeignKey(UserIdColumnName);

		builder.Navigation(x => x.User)
			.AutoInclude();
	}
}
