﻿using System.ComponentModel.DataAnnotations;

namespace Shopping.Application.Dtos;

public sealed record ItemDto
{ 
    [Required]
    public string Name { get; init; }
    [Required]
    public float Unit { get; init; }
    [Required]
    public int Quantity { get; init; }
    public bool IsPurchased { get; init; }
    [Required]
    public decimal Price { get; init; }
    [Required]
    public  int CategoryId { get; init; }
    [Required]
    public int ShoppingListId { get; init; }
}