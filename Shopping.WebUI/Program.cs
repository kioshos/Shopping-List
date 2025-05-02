using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Shopping.Application.CQRS.Commands;
using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Handlers;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Application.Mediator;
using Shopping.Application.Services;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.Classes;
using Shopping.Infrastructure.Classes.Installers;
using Shopping.Infrastructure.Repository;
using Shopping.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-GB"),
        new CultureInfo("uk"),
    };
    
    options.DefaultRequestCulture = new RequestCulture("en-GB");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);

builder.Services.AddScoped<IItemServices, ItemService>();
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireLowercase = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultUI();



builder.Services.AddScoped<IGenericRepository<Item>, GenericRepository<Item>>();
builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<ShoppingList>, GenericRepository<ShoppingList>>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();

builder.Services.AddTransient<ICommandHandler<AddItemCommand>, AddItemCommandHandler>();
builder.Services.AddTransient<ICommandHandler<RemoveShoppingListCommand>, RemoveShoppingListCommandHandler>();
builder.Services.AddTransient<ICommandHandler<UpdateItemPurchaseStatusCommand>, UpdateItemPurchaseStatusCommandHandler>();
builder.Services.AddTransient<ICommandHandler<CreateShoppingListCommand>, CreateShoppingLIstCommandHandler>();
builder.Services.AddTransient<IQueryHandler<GetCategoryByIdQuery, CategoryDto>, GetCategoryByIdQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>, GetAllCategoriesQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetAllShoppingListsQuery, List<ShoppingListDto>>, GetAllShoppingListsQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetShoppingListByIdQuery, ShoppingListDto>, GetShoppingLIstByIdQueryHandler>();
builder.Services.AddTransient<IQueryHandler<GetItemsInShoppingListQuery, List<ItemDto>>, GetItemsInShoppingListQueryHandler>();
builder.Services.AddTransient<IMediator,Mediator>();


builder.Services.AddRazorPages();


// Add Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentityInitializer.SeedRolesAsync(services);
}

app.UseRequestLocalization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();