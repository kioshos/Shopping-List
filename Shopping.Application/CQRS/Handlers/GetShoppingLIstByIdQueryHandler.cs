using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;

namespace Shopping.Application.CQRS.Handlers;

public class GetShoppingLIstByIdQueryHandler : IQueryHandler<GetShoppingListByIdQuery, ShoppingListDto>
{
    private readonly IShoppingListService _shoppingListService;

    public GetShoppingLIstByIdQueryHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<ShoppingListDto> HandleAsync(GetShoppingListByIdQuery query)
    {
        return await _shoppingListService.GetShoppingListById(query.Id);
    }
}