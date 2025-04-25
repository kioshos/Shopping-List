using Shopping.Application.CQRS.Core;
using Shopping.Application.CQRS.Query;
using Shopping.Application.Dtos;
using Shopping.Application.Interfaces;
using Shopping.Domain.Entities;
using Shopping.Infrastructure.UnitOfWork;

namespace Shopping.Application.CQRS.Handlers;

public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ICategoryService _categoryService;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<CategoryDto> HandleAsync(GetCategoryByIdQuery byIdQuery)
    {
        return await _categoryService.GetCategoryByIdAsync(byIdQuery.Id);
    }
    
}