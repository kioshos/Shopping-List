using Shopping.Application.Dtos;

namespace Shopping.Application.Interfaces;

public interface IShoppingListService
{
    Task<List<ShoppingListDto>> GetShoppingListsAsync();
    Task CreateShoppingListAsync(ShoppingListDto shoppingListDto);
}