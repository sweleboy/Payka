using Payka.Domain.Rules;

namespace Payka.Domain.Models.Wallets.Rules;
public class CheckWalletCanBeMarkedAsGroupedRulepublic(Wallet wallet) : IBusinessRule
{
	public string Message => "Невозможно отметить кошелёк групповым. Причина: кошелёк уже является групповым.";

	public bool IsFailure() => wallet.IsGroupWallet;
}