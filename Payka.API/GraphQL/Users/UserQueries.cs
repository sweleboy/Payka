using HotChocolate.Language;
using HotChocolate.Types;

namespace Payka.API.GraphQL.Users
{
	[ExtendObjectType(OperationType.Query)]
	public class UserQueries
	{
		public int GetNumber() => 0;
	}
}
