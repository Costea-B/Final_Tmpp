using App.Services;
using Domain.DbModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationQueryController : ControllerBase
    {
        private readonly ReservationQueryService _reservationQueryService;
        public ReservationQueryController(ReservationQueryService reservationQueryService)
        {
            _reservationQueryService = reservationQueryService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Reservation>>> GetAllReservations()
        {
            var reservations = await _reservationQueryService.GetAllReservationsAsync();
            return Ok(reservations);
        }
    }
}
