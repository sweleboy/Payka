using Payka.Domain.Rules;

namespace Payka.Domain.Models.Users.Rules;
public class CheckUserIsContainsInMembersRule(IReadOnlyCollection<User> members,
	Guid potentialMemberId) : IBusinessRule
{
	public string Message => "Невозможно удалить пользователя из группы. Причина: пользователь не содержиться в этой группе.";

	public bool IsFailure() => !members.Select(x => x.Id).Contains(potentialMemberId);
}