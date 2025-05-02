using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Query;

public class GetShoppingListByIdQuery : IQuery
{
    public int Id { get; init; }
}