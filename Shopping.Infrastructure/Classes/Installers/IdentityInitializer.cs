using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Shopping.Infrastructure.Classes.Installers;

public class IdentityInitializer
{
    
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

       string[] roleNames = { "Admin", "User" };
       
       foreach (var role in roleNames)
       {
           var roleExist = await roleManager.RoleExistsAsync(role);

           if (!roleExist)
           {
               await roleManager.CreateAsync(new IdentityRole(role));
           }
       }
       
       string adminEmail = "petro22@gmail.com";

       var user = await userManager.FindByEmailAsync(adminEmail);
       if (user != null)
       {
           await userManager.AddToRoleAsync(user, "Admin");
       }

    }
}