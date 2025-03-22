using Shopping.Application.Dtos;

namespace Shopping.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
}