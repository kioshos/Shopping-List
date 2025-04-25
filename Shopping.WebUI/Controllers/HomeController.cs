using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Application.Mediator;
using Shopping.WebUI.Models;

namespace Shopping.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;
    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var shoppingLists = await _mediator.SendAsync<GetAllShoppingListsQuery, List<ShoppingListDto>>(new GetAllShoppingListsQuery());
        ViewBag.ShoppingLists = shoppingLists;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateList(string listName)
    {
        if (!string.IsNullOrWhiteSpace(listName))
        {
            var command = new CreateShoppingListCommand
            {
                Name = listName,
                Created = DateTime.Now
            };
            
            await _mediator.SendAsync(command);
        }

        return RedirectToAction("Index");
    }
}
// TODO натискаєш на ShoppingList і там можна побачити всі айтеми що там є і дата створення ShoppingList
// TODO хрестики