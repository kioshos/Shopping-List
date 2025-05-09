using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Core;
using Shopping.Application.Dtos;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.CQRS.Handlers;

public class CreateShoppingLIstCommandHandler : ICommandHandler<CreateShoppingListCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateShoppingLIstCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(CreateShoppingListCommand command)
    {
        ShoppingList shoppingList = new ShoppingList
        {
            Id = command.Id,
            Name = command.Name,
            CreatedDate = command.Created,
            UserId = command.UserId
        };
        await _unitOfWork.ShoppingList.AddAsync(shoppingList);
        await _unitOfWork.SaveChangesAsync();
    }
    
}