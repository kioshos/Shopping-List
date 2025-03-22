using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.Services;

public class ItemService : IItemServices
{
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task AddItemAsync(ItemDto itemDto)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(itemDto.CategoryId);
        var shoppingList = await  _unitOfWork.ShoppingList.GetByIdAsync(itemDto.ShoppingListId);
        var item = new Item()
        {
            Name = itemDto.Name,
            Price = itemDto.Price,
            Quantity = itemDto.Quantity,
            Category = category,
            ShoppingList = shoppingList
        };

        await _unitOfWork.Item.AddAsync(item);  
        await _unitOfWork.SaveChangesAsync(); 
    }
    
}