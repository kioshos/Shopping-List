using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Core;
using Shopping.Application.Dtos;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.CQRS.Handlers;

public class AddItemCommandHandler : ICommandHandler<AddItemCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddItemCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(AddItemCommand command)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(command.CategoryId);
        var shoppingList = await _unitOfWork.ShoppingList.GetByIdAsync(command.ShoppingListId);
        
        Item newItem = new Item()
        {
            Name = command.Name,
            Unit = command.Unit,
            Quantity = command.Quantity,
            IsPurchased = command.IsPurchased,
            Price = command.Price,
            Category = category,
            ShoppingList = shoppingList
        };
        await _unitOfWork.Item.AddAsync(newItem);
        await _unitOfWork.SaveChangesAsync();
    }
}