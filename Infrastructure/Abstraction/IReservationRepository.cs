using Domain.DbModel;
using Domain.Enum;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infrastructure.Abstraction
{
    public interface IReservationRepository
    {
        Task AddReservationAsync(Reservation reservation);
        Task<bool> UpdateReservationStateAsync(int reservationId, ReservationState newState);
        Task<Reservation> GetByIdAsync(int reservationId);
        Task<int?> CreateReservationWithTemplateTableAsync(Guid templateId, DateTime date, int guests, string userId, int restaurantId);
        Task<List<Reservation>> GetAllReservationsAsync();
        // Poți adăuga și alte metode, ex: Get, Update, Delete
    }
}
