using Domain.DbModel;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface ITableRepository
    {
        Task AddTableAsync(Table table);
        Task<bool> RestaurantExistsAsync(int restaurantId);
    }
}
