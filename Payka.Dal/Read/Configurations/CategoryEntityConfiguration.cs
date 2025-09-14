using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.ReadModel.Models;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M002_CreateCategoryTableMigration;

namespace Payka.Dal.Read.Configurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
	public void Configure(EntityTypeBuilder<CategoryEntity> builder)
	{
		builder.ToTable(TableName);
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
	}
}