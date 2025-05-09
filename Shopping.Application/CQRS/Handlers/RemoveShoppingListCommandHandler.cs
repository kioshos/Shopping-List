using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Core;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.CQRS.Handlers;

public class RemoveShoppingListCommandHandler : ICommandHandler<RemoveShoppingListCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveShoppingListCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task HandleAsync(RemoveShoppingListCommand command)
    {
        var shoppingList = await _unitOfWork.ShoppingList.GetByIdAsync(command.Id);
        
        await _unitOfWork.ShoppingList.DeleteAsync(shoppingList.Id);
        
        await _unitOfWork.SaveChangesAsync();
    }
}