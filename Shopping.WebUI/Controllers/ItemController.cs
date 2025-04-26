using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Interfaces;
using Shopping.WebUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Mediator;

namespace Shopping.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("AddItem")]
        public async Task<ViewResult> Index()
        {
            var categories = await _mediator.SendAsync<GetAllCategoriesQuery, List<CategoryDto>>(new GetAllCategoriesQuery());

           var shoppingLists = await _mediator.SendAsync<GetAllShoppingListsQuery, List<ShoppingListDto>>(new GetAllShoppingListsQuery());
                
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            
            ViewBag.ShoppingLists = shoppingLists.Select(l => new SelectListItem
             {
                Value = l.Id.ToString(),
                 Text = l.Name
             }).ToList();

            
            return View();
        }
        public async Task<IActionResult> AddItem()
        {
            var categories = await _mediator.SendAsync<GetAllCategoriesQuery, List<CategoryDto>>(new GetAllCategoriesQuery());
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(new AddItemModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.SendAsync(command);
            }
            
            return RedirectToAction("Index"); 
        }
    }
}