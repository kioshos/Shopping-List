namespace Shopping.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Unit { get; set; }
    public int Quantity { get; set; }
    public bool IsPurchased { get; set; }
    public decimal Price { get; set; }
    public  Category Category { get; set; }
    public ShoppingList ShoppingList { get; set; }
}