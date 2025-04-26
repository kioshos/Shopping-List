namespace Shopping.Application.Dtos
{
    public sealed record CategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}