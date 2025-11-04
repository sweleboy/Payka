using Payka.Domain.Rules;

namespace Payka.Domain.Models.Users.Rules;
public class CheckUserIsNotContainsInMembersRule(IReadOnlyCollection<UserGroupMember> members,
	UserGroupMember potentialMember) : IBusinessRule
{
	public string Message => "Невозможно добавить пользователя в группу. Причина: пользователь уже содержиться в этой группе.";

	public bool IsFailure() => members.Select(x => x.User.Id).Contains(potentialMember.User.Id);
}