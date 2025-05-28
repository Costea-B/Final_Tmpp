using Domain.DbModel;
using System.Threading.Tasks;
using App.State;

namespace App.State
{
    public class ReservationContext
    {
        private ReservationStateBase _state;
        public ReservationContext(ReservationStateBase state)
        {
            _state = state;
        }
        public void SetState(ReservationStateBase state)
        {
            _state = state;
        }
        public Task ApplyAsync(Reservation reservation)
        {
            return _state.HandleAsync(reservation);
        }
    }
}
