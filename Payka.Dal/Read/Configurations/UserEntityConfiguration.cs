using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.ReadModel.Models.Users;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M001_CreateUserTableMigration;

namespace Payka.Dal.Read.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
	public void Configure(EntityTypeBuilder<UserEntity> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.CreateDate)
			.HasColumnName(CreatedDateColumnName);
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