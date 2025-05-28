using System.Threading.Tasks;
using Domain.DbModel;
using App.Abstraction;

namespace App.ChainOfResponsibility
{
    // Handler pentru validarea numărului de persoane
    public class GuestsValidationHandler : ReservationHandler
    {
        public override async Task<bool> HandleAsync(Reservation reservation)
        {
            if (reservation.NumberOfGuests <= 0)
                return false; // Invalid
            if (_next != null)
                return await _next.HandleAsync(reservation);
            return true;
        }
    }

    // Handler pentru validarea datei
    public class DateValidationHandler : ReservationHandler
    {
        public override async Task<bool> HandleAsync(Reservation reservation)
        {
            if (reservation.Date < System.DateTime.Now)
                return false; // Invalid
            if (_next != null)
                return await _next.HandleAsync(reservation);
            return true;
        }
    }

    // Handler pentru validarea restaurantului
    public class RestaurantValidationHandler : ReservationHandler
    {
        private readonly Infrastructure.Abstraction.IRestaurantRepository _restaurantRepository;
        public RestaurantValidationHandler(Infrastructure.Abstraction.IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public override async Task<bool> HandleAsync(Reservation reservation)
        {
            var exists = await _restaurantRepository.RestaurantExistsAsync(reservation.RestaurantId);
            if (!exists)
                return false;
            if (_next != null)
                return await _next.HandleAsync(reservation);
            return true;
        }
    }
}
