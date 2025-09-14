using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Domain.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M001_CreateUserTableMigration;

namespace Payka.Dal.Write.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.FullName)
			.HasColumnName(FullNameColumnName)
			.IsRequired();

		builder.Property(x => x.UserName)
			.HasColumnName(UserNameColumnName)
			.IsRequired();
	}
}