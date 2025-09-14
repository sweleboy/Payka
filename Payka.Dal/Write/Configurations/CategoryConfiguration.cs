using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.Domain.Models;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M002_CreateCategoryTableMigration;

namespace Payka.Dal.Write.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
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
	}
}