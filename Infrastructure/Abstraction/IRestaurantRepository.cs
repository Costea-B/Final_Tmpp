using Domain.DbModel;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface IRestaurantRepository
    {
        Task<bool> RestaurantExistsAsync(int restaurantId);
    }
}
