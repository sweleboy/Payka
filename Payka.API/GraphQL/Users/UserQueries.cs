using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using Payka.Dal;
using Payka.Domain.Models.Users;
using Payka.ReadModel.Models.Users;

namespace Payka.API.GraphQL.Users
{
	[ExtendObjectType(OperationType.Query)]
	public class UserQueries
	{
		public IQueryable<UserGroup> GetNumber([Service] WriteDbContext dbContext)
		{
			var a = dbContext.Groups.FirstOrDefault();
			a.ChangeName("test");
			dbContext.SaveChanges();

			return dbContext.Groups.AsQueryable();
		}
		public IQueryable<UserGroupEntity> GetGroups([Service] ReadDbContext dbContext) => dbContext.GroupEntities;
	}
}