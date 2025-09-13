using Payka.Domain.Models.Base;

namespace Payka.Domain.Models.Politics;

public class GroupSpendingPolicy : DomainModelBase
{
	public bool ApprovalRequired { get; private set; }

	public Money? ApprovalThreshold { get; private set; }

	public bool AllowTransfers { get; private set; }

	private GroupSpendingPolicy() { }

	private GroupSpendingPolicy(Guid id, bool approvalRequired, Money? approvalThreshold, bool allowTransfers)
	{
		Id = id;
		ApprovalRequired = approvalRequired;
		ApprovalThreshold = approvalThreshold;
		AllowTransfers = allowTransfers;
	}

	public static GroupSpendingPolicy Create(Guid id, bool approvalRequired = false, Money? approvalThreshold = null, bool allowTransfers = true)
	{
		return new GroupSpendingPolicy(id, approvalRequired, approvalThreshold, allowTransfers);
	}
}