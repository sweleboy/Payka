using Payka.Application.Contracts.CQRS;

namespace Payka.Application.UseCases.CreateWallets;

public record CreateWalletCommand(string Name, Guid OwnerId, string Note, Guid CurrencyId) : ICommand;