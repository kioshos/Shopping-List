using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.WebUI.Controllers;

public class ItemController : Controller
{
    private readonly IItemServices _itemServices;
    
    public ItemController(IItemServices itemServices)
    
    {
        _itemServices = itemServices;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(ItemDto itemDto)
    {
       
        if (ModelState.IsValid)
        {
            await _itemServices.AddItemAsync(itemDto);
            return RedirectToAction("Index");
        }

        return View(itemDto);
    }
}