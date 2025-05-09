using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;

namespace Shopping.Application.CQRS.Handlers;

public class GetAllShoppingListsByUserIdHandler : IQueryHandler<GetAllShoppingListsByUserIdQuery, List<ShoppingListDto>>
{
    private readonly IShoppingListService _shoppingListService;

    public GetAllShoppingListsByUserIdHandler(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }
    public async Task<List<ShoppingListDto>> HandleAsync(GetAllShoppingListsByUserIdQuery query)
    {
        return _shoppingListService.GetAllShoppingListsAsync().Result.FindAll(user => user.UserId == query.UserId).ToList();
    }
}