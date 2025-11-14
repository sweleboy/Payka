using Payka.Domain.Models.Common;
using Payka.Domain.Rules;

namespace Payka.Domain.Models.Wallets.Rules;
public class CheckWalletIsNotContainsInGroupWalletsRule(IReadOnlyCollection<GroupWallet> wallets,
	GroupWallet potentialWallet) : IBusinessRule
{
	public string Message => "Невозможно добавить кошелёк в группу. Причина: кошелёк уже содержиться в этой группе.";

	public bool IsFailure() => wallets.Select(x => x.Id).Contains(potentialWallet.Id);
}
