namespace Shopping.Domain.Entities;

public class PurchaseHistory
{
    public int Id { get; set; }
    public string ShoppingName { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Price { get; set; }
    public ShoppingList ShoppingList { get; set; }
    public Category Category { get; set; }
}