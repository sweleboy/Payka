using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Payka.Dal;
using Payka.ReadModel.Models;

namespace Payka.API.GraphQL.Queries;

[ExtendObjectType(OperationType.Query)]
public class CurencyQueries
{
	public IQueryable<CurrencyEntity> GetCurrenciesAsync([Service] ReadDbContext dbContext) => dbContext.Currencies;
}