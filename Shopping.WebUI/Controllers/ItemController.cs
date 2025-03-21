using Microsoft.AspNetCore.Mvc;
using Shopping.Application.Interfaces;
using Shopping.WebUI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Application.Dtos;

namespace Shopping.WebUI.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IItemServices _itemService;

        public ItemController(ICategoryService categoryService, IItemServices itemService)
        {
            _categoryService = categoryService;
            _itemService = itemService;
        }
        [Route("AddItem")]
        public async Task<ViewResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
                
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            
            return View();
        }
        public async Task<IActionResult> AddItem()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            return View(new AddItemModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemModel model)
        {

            var itemDto = new ItemDto
            {
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity,
                CategoryId = model.CategoryId,
                ShoppingListId = model.ShoppingListId
            };

            await _itemService.AddItemAsync(itemDto);
            return RedirectToAction("Index"); 
        }
    }
}