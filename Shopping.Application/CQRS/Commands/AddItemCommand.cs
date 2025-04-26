using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Commands;

public class AddItemCommand : ICommand
{
    public string Name { get; init; }
    public float Unit { get; init; }
    public int Quantity { get; init; }
    public bool IsPurchased { get; init; }
    public decimal Price { get; init; }
    public  int CategoryId { get; init; }
    public int ShoppingListId { get; init; }
}