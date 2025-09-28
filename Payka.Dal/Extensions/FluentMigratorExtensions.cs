using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using static Payka.Dal.Constants.CommonColumnNames;

namespace Payka.Dal.Extensions;

public static class FluentMigratorExtensions
{
	public static ICreateTableWithColumnSyntax AddBaseReadModelAudit(this ICreateTableWithColumnSyntax table)
	{
		table.WithColumn(IsDeleteColumnName).AsBoolean().NotNullable().WithDefaultValue(false)
			 .WithColumn(CreatedDateColumnName).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);

		return table;
	}
}