using System.ComponentModel.DataAnnotations;
using Shopping.WebUI.Models.Attributes;

namespace Shopping.WebUI.Models;

public class AddItemModel
{
    [Display(Name = "Name")]
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public string Name { get; set; }
    

    [Display(Name = "Unit")]
    [Required]
    public float Unit { get; set; }
    
    [PositiveNumbers]
    [Display(Name = "Quantity")]
    [Required]
    public int Quantity { get; set; }
    
    public bool IsPurchased { get; set; }
    

    [Display(Name = "Price")]
    [Required]
    public decimal Price { get; set; }
    
    [Display(Name = "CategoryId")]
    [Required]
    public  int CategoryId { get; set; }
    
    [PositiveNumbers]
    [Display(Name = "ShoppingListId")]
    [Required]
    public int ShoppingListId { get; set; }
}