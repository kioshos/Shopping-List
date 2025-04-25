using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;

namespace Shopping.Application.CQRS.Handlers;

public class GetAllShoppingListsQueryHandler : IQueryHandler<GetAllShoppingListsQuery, List<ShoppingListDto>>
{
    private readonly IShoppingListService _shoppingListService;

    public GetAllShoppingListsQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<List<ShoppingListDto>> HandleAsync(GetAllShoppingListsQuery query)
    {
        return await _shoppingListService.GetAllShoppingListsAsync();
    }
}