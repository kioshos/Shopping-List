using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync();
        Console.WriteLine(categories.Count);
        return categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name }).ToList();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        return new CategoryDto { Id = category.Id, Name = category.Name };
    }
}