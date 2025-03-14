namespace Shopping.Application.Dtos;

public sealed record ItemDto
{ 
    public string Name { get; set; }
    public float Unit { get; set; }
    public int Quantity { get; set; }
    public bool IsPurchased { get; set; }
    public decimal Price { get; set; }
    public  int CategoryId { get; set; }
    public int ShoppingListId { get; set; }
}