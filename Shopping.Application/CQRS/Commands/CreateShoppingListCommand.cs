using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Commands;

public class CreateShoppingListCommand : ICommand
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime Created { get; init; }
    public string UserId { get; init; }
}