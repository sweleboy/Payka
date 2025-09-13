using Payka.ReadModel.Models.Base;

namespace Payka.ReadModel.Models;

public class GroupSpendingPolicyEntity : ReadModelBase
{
	public Guid Id { get; set; }
	public bool ApprovalRequired { get; set; }
	public MoneyEntity? ApprovalThreshold { get; set; }
	public bool AllowTransfers { get; set; }
}