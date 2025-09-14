using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Payka.Domain.Models;
using static Payka.Dal.Constants.CommonColumnNames;
using static Payka.Dal.Migrations.M003_CreateCurrencyTableMigration;

namespace Payka.Dal.Write.Configurations;
	internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
	{
		public void Configure(EntityTypeBuilder<Currency> builder)
		{
			builder.ToTable(TableName);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.HasColumnName(IdColumnName);
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
