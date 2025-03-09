namespace Shopping.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Item> Items { get; set; } = new List<Item>();
}