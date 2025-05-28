using Domain.Enum;
using System.Threading.Tasks;
using Domain.DbModel;
using Infrastructure.Abstraction;

namespace App.Services
{
    public class ReservationStateService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationStateService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<bool> UpdateReservationStateAsync(int reservationId, ReservationState newState)
        {
            var reservation = await _reservationRepository.GetByIdAsync(reservationId);
            if (reservation == null)
                return false;

            App.State.ReservationStateBase state = newState switch
            {
                ReservationState.New => new App.State.NewState(),
                ReservationState.Confirmed => new App.State.ConfirmedState(),
                ReservationState.Cancelled => new App.State.CancelledState(),
                ReservationState.Completed => new App.State.CompletedState(),
                _ => new App.State.NewState()
            };
            var context = new App.State.ReservationContext(state);
            await context.ApplyAsync(reservation);
            return await _reservationRepository.UpdateReservationStateAsync(reservationId, reservation.State);
        }
    }
}
