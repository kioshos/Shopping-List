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

    public async Task<List<ShoppingListDto>> GetAllShoppingListsAsync()
    {
        var shoppingLists = await _unitOfWork.ShoppingList.GetAllAsync();
        return shoppingLists
            .Select(sh => new ShoppingListDto 
            { 
                Id = sh.Id, 
                Name = sh.Name, 
                Created = sh.CreatedDate,
                UserId = sh.UserId
            })
            .ToList();
    }

    public async Task CreateShoppingListAsync(ShoppingListDto shoppingListDto)
    {
        
        var shoppingList = new ShoppingList()
        {
            Name = shoppingListDto.Name,
            CreatedDate = shoppingListDto.Created,
            UserId = shoppingListDto.UserId
        };
        await _unitOfWork.ShoppingList.AddAsync(shoppingList);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<ShoppingListDto> GetShoppingListById(int id)
    {
        var shoppingList = await _unitOfWork.ShoppingList.GetByIdAsync(id);

        return new ShoppingListDto
        {
            Id = shoppingList.Id,
            Name = shoppingList.Name,
            Created = shoppingList.CreatedDate,
            UserId = shoppingList.UserId
        };
    }
    public async Task<List<ItemDto>> GetItemsByShoppingListIdAsync(int shoppingListId)
    {
        var items = await _unitOfWork.Item.GetAllAsync();
    
        var filteredItems = items
            .Where(item => item.ShoppingList != null && item.ShoppingList.Id == shoppingListId)
            .Select(item => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Unit = item.Unit,
                Quantity = item.Quantity,
                IsPurchased = item.IsPurchased,
                Price = item.Price,
                CategoryId = item.Category != null ? item.Category.Id : 0,
                ShoppingListId = item.ShoppingList.Id
            })
            .ToList();

        return filteredItems;
    }

}