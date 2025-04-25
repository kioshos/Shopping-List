using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Query;

public class GetCategoryByIdQuery : IQuery
{
    public int Id { get; init; }
}