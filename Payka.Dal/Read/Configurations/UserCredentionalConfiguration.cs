using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.ReadModel.Models.Users;
using static Payka.Dal.Migrations.M010_AddUserCredantionalsTableMigration;

namespace Payka.Dal.Read.Configurations;

public class UserCredentionalConfiguration : IEntityTypeConfiguration<UserCredentional>
{
	public void Configure(EntityTypeBuilder<UserCredentional> builder)
	{
		builder.ToTable(TableName);

		builder.HasKey(x => x.UserId);

		builder.Property(x => x.UserId)
			.HasColumnName(UserIdColumnName);
		builder.Property(x => x.UserName)
			.HasColumnName(UserNameColumnName);
		builder.Property(x => x.Password)
			.HasColumnName(PasswordColumnName);
	}
}