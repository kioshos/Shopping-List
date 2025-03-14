using Shopping.Application.Dtos;
using Shopping.Domain.Entities;

namespace Shopping.Application.Interfaces;

public interface IItemServices
{
    Task AddItemAsync(ItemDto item);
}