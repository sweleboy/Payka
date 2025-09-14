using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payka.ReadModel.Models;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M003_CreateCurrencyTableMigration;

namespace Payka.Dal.Configurations;

public class CurrencyEntityConfiguration : IEntityTypeConfiguration<CurrencyEntity>
{
	public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
	{
		builder.ToTable(TableName);
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Id)
			.HasColumnName(IdColumnName);
		builder.Property(x => x.CreateDate)
			.HasColumnName(CreatedDateColumnName);
		builder.Property(x => x.IsDeleted)
			.HasColumnName(IsDeleteColumnName);

		builder.Property(x => x.Code)
			.HasColumnName(CodeColumnName)
			.HasMaxLength(8)
			.IsRequired();
		builder.Property(x => x.Symbol)
			.HasColumnName(SymbolColumnName)
			.HasMaxLength(8);
		builder.Property(x => x.RublesValue)
			.HasColumnName(RublesValueColumnName)
			.HasColumnType("decimal(19,6)")
			.IsRequired();
	}
}