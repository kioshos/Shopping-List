using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.WebUI.Models;

namespace Shopping.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly IShoppingListService _shoppingListService;

    public HomeController(IShoppingListService shoppingListService)
    {
        _shoppingListService = shoppingListService;
    }

    public async Task<IActionResult> Index()
    {
        var shoppingLists = await _shoppingListService.GetShoppingListsAsync();
        ViewBag.ShoppingLists = shoppingLists;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateList(string listName)
    {
        if (!string.IsNullOrWhiteSpace(listName))
        {
            var newList = new ShoppingListDto
            {
                Name = listName,
                Created = DateTime.Now
            };

            await _shoppingListService.CreateShoppingListAsync(newList);
        }

        return RedirectToAction("Index");
    }
}
// TODO натискаєш на ShoppingList і там можна побачити всі айтеми що там є і дата створення ShoppingList