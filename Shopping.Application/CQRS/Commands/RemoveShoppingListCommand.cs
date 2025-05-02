using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Commands;

public class RemoveShoppingListCommand : ICommand
{
    public int Id { get; init; }
}