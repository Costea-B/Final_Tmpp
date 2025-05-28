using Domain.DbModel;
using Infrastructure.Abstraction;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services
{
    public class ReservationQueryService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationQueryService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _reservationRepository.GetAllReservationsAsync();
        }
    }
}
