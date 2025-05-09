using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Application.Mediator;
using Shopping.WebUI.Models;

namespace Shopping.WebUI.Controllers;
[Authorize(Roles = "User")]
public class HomeController : Controller
{
    private readonly IMediator _mediator;
    public HomeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        var shoppingLists = await _mediator.SendAsync<GetAllShoppingListsByUserIdQuery, List<ShoppingListDto>>(new GetAllShoppingListsByUserIdQuery { UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)});
        ViewBag.ShoppingLists = shoppingLists;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateList(string listName)
    {   
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrWhiteSpace(listName))
        {
            var command = new CreateShoppingListCommand
            {
                Name = listName,
                Created = DateTime.Now,
                UserId = userId
            };

            await _mediator.SendAsync(command);
        }


        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteList(RemoveShoppingListCommand command)
    {
        var shoppingListToRemove = new RemoveShoppingListCommand { Id = command.Id };
    
        await _mediator.SendAsync(shoppingListToRemove);

        return RedirectToAction("Index");
    }
}
