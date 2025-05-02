using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;

namespace Shopping.Application.CQRS.Handlers;

public class GetItemsInShoppingListQueryHandler : IQueryHandler<GetItemsInShoppingListQuery, List<ItemDto>>
{
    private readonly IShoppingListService _shoppingListService;

    public GetItemsInShoppingListQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }

    public async Task<List<ItemDto>> HandleAsync(GetItemsInShoppingListQuery query)
    {
        return await _shoppingListService.GetItemsByShoppingListIdAsync(query.ShoppingListId);
    }
}