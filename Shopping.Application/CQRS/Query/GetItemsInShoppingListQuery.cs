using Shopping.Application.CQRS.Core;

namespace Shopping.Application.CQRS.Query;

public class GetItemsInShoppingListQuery : IQuery
{
    public int ShoppingListId { get; set; }
}