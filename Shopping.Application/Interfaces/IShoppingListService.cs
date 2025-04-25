using Shopping.Application.Dtos;

namespace Shopping.Application.Interfaces;

public interface IShoppingListService
{
    Task<List<ShoppingListDto>> GetAllShoppingListsAsync();
    Task CreateShoppingListAsync(ShoppingListDto shoppingListDto);
}