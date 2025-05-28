using System.Threading.Tasks;
using Domain.DbModel;

namespace App.Abstraction
{
    public abstract class ReservationHandler
    {
        protected ReservationHandler _next;
        public void SetNext(ReservationHandler next)
        {
            _next = next;
        }
        public abstract Task<bool> HandleAsync(Reservation reservation);
    }
}
