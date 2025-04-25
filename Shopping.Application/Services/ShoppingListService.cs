using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.Services;

public class ShoppingListService : IShoppingListService

{
    private readonly IUnitOfWork _unitOfWork;

    public ShoppingListService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ShoppingListDto>> GetShoppingListsAsync()
    {
        var shoppingLists = await _unitOfWork.ShoppingList.GetAllAsync();
        return shoppingLists
            .Select(sh => new ShoppingListDto 
            { 
                Id = sh.Id, 
                Name = sh.Name, 
                Created = sh.CreatedDate 
            })
            .ToList();
    }

    public async Task CreateShoppingListAsync(ShoppingListDto shoppingListDto)
    {
        var shoppingList = new ShoppingList()
        {
            Name = shoppingListDto.Name,
            CreatedDate = shoppingListDto.Created
        };
        await _unitOfWork.ShoppingList.AddAsync(shoppingList);
        await _unitOfWork.SaveChangesAsync();
    }
}