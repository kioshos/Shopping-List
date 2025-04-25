using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;

namespace Shopping.Application.CQRS.Handlers;

public class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<List<CategoryDto>> HandleAsync(GetAllCategoriesQuery query)
    {
        return await _categoryService.GetAllCategoriesAsync();
    }
}