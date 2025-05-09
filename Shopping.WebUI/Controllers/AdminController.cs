using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.Mediator;

namespace Shopping.WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    public AdminController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users); 
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id )
    {
        var userToDelete = _userManager.Users.FirstOrDefault(u => u.Id == id);

        if (userToDelete != null)
        {
            await _userManager.DeleteAsync(userToDelete);
        }

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> PromoteToAdmin(string id )
    {
        var userToPromote = _userManager.Users.FirstOrDefault(u => u.Id == id);
        
        if (userToPromote != null)
        {
            await _userManager.AddToRoleAsync(userToPromote, "Admin");
        }

        return RedirectToAction("Index");
    }
}