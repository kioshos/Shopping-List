using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Commands;

public class UpdateItemPurchaseStatusCommand : ICommand
{
    public int ItemId { get; init; }
    public bool IsPurchased { get; init; }
}