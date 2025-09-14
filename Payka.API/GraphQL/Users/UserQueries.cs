using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Payka.Dal;
using Payka.ReadModel.Models.Users;

namespace Payka.API.GraphQL.Users
{
	[ExtendObjectType(OperationType.Query)]
	public class UserQueries
	{
		public IQueryable<UserGroupEntity> GetNumber([Service] ReadDbContext dbContext) => dbContext.GroupEntities;
	}
}