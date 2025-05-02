using Microsoft.AspNetCore.Mvc;
using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Mediator;

namespace Shopping.WebUI.Controllers;

public class ShoppingListController : Controller
{
    private readonly IMediator _mediator;

    public ShoppingListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Details(int id)
    {
        var shoppingList = await _mediator.SendAsync<GetShoppingListByIdQuery, ShoppingListDto>(new GetShoppingListByIdQuery { Id = id });
        var items = await _mediator.SendAsync<GetItemsInShoppingListQuery, List<ItemDto>>(new GetItemsInShoppingListQuery { ShoppingListId = id });

        ViewBag.ShoppingList = shoppingList;
        ViewBag.Items = items;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> TogglePurchaseStatus(int itemId, int shoppingListId, bool isPurchased)
    {
        var command = new UpdateItemPurchaseStatusCommand
        {
            ItemId = itemId,
            IsPurchased = isPurchased
        };

        await _mediator.SendAsync(command);

        return RedirectToAction(nameof(Details), new { id = shoppingListId });
    }
}
// TODO add opportunity to make custom categories
// TODO make total spendings