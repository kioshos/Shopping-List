using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Query;

public class GetAllShoppingListsByUserIdQuery : IQuery
{
    public string UserId { get; set; }
}