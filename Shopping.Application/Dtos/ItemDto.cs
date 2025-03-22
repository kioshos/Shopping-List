using System.ComponentModel.DataAnnotations;

namespace Shopping.Application.Dtos;

public sealed record ItemDto
{ 
    [Required]
    public string Name { get; set; }
    [Required]
    public float Unit { get; set; }
    [Required]
    public int Quantity { get; set; }
    public bool IsPurchased { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public  int CategoryId { get; set; }
    [Required]
    public int ShoppingListId { get; set; }
}