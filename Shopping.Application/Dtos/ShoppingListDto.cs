namespace Shopping.Application.Dtos;

public sealed record ShoppingListDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateTime Created { get; init; }
}