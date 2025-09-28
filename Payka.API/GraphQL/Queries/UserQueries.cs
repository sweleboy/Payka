using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Payka.Dal;
using Payka.ReadModel.Models.Users;

namespace Payka.API.GraphQL.Queries
{
	[ExtendObjectType(OperationType.Query)]
	public class UserQueries
	{
		public IQueryable<UserGroupEntity> GetGroups([Service] ReadDbContext dbContext) => dbContext.GroupEntities;
	}
}