using App.Services;
using Domain.DbModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationServices _reservationServices;
        public ReservationController(ReservationServices reservationServices)
        {
            _reservationServices = reservationServices;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ReservationCreateRequest request)
        {
            var reservation = new Reservation
            {
                Date = request.Date,
                NumberOfGuests = request.NumberOfGuests,
                UserId = request.UserId,
                ReservationTypeId = request.ReservationTypeId,
                RestaurantId = request.RestaurantId
            };
            var result = await _reservationServices.CreateReservationAsync(reservation);
            if (!result)
                return BadRequest("Rezervarea nu a trecut validarea.");
            return Ok("Rezervare creată cu succes.");
        }
    }
}
