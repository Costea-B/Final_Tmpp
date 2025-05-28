using App.Abstraction;
using Domain.DbModel;
using System.Threading.Tasks;

namespace App.ChainOfResponsibility
{
    public class ReservationValidationService
    {
        private readonly ReservationHandler _chain;
        public ReservationValidationService(ReservationHandler chain)
        {
            _chain = chain;
        }
        public async Task<bool> ValidateAsync(Reservation reservation)
        {
            return await _chain.HandleAsync(reservation);
        }
    }
}
