namespace Shopping.Domain.Entities;

public class ShoppingList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
}