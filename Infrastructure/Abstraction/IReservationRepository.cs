using Domain.DbModel;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
    public interface IReservationRepository
    {
        Task AddReservationAsync(Reservation reservation);
        // Poți adăuga și alte metode, ex: Get, Update, Delete
    }
}
