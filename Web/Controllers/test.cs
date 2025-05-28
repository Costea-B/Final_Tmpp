using App.Facede;
using App.Factory;
using Domain.Enum;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class test : ControllerBase
     {
          private readonly ILoggerService _logger;
          private readonly ReservationFacade _reservationFacade;
          private readonly IReservationFactory _factory;
          private readonly App.Services.ReservationStateService _reservationStateService;

          public test(ILoggerService logger, ReservationFacade reservationFacade, IReservationFactory factory, App.Services.ReservationStateService reservationStateService)
          {
            _logger = logger;
            _reservationFacade = reservationFacade;
            _factory = factory;
            _reservationStateService = reservationStateService;
          }

          [HttpGet("info")]
          public IActionResult LogInfoTest()
          {
               _logger.LogInfo("This is an information message from the API controller");
               return Ok("Information logged successfully");
          }

          [HttpGet("warning")]
          public IActionResult LogWarningTest()
          {
               _logger.LogWarning("This is a warning message from the API controller");
               return Ok("Warning logged successfully");
          }

          [HttpGet("error")]
          public IActionResult LogErrorTest()
          {
               try
               {
                    // Simulate an error
                    throw new Exception("This is a simulated exception");
               }
               catch (Exception ex)
               {
                    _logger.LogError("An error occurred in the API controller", ex);
                    return BadRequest("Error logged successfully");
               }
          }

          [HttpPost("make-reservation")]
          public IActionResult MakeReservation([FromQuery] string email, [FromQuery] DateTime date, [FromQuery] int persons, [FromQuery] int restaurantId, [FromQuery] int reservationTypeId)
          {
               _reservationFacade.MakeReservation(email, date, persons, restaurantId, reservationTypeId);
               return Ok("Rezervarea a fost trimisă.");
          }

          [HttpPost("allocate")]
          public IActionResult Allocate([FromQuery] string type, [FromQuery] int guests, [FromQuery] string userId, [FromQuery] int restaurantId)
          {
            try
            {
                var reservation = _factory.CreateReservation(type);
                var result = reservation.Allocate(guests, userId, restaurantId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          }

          [HttpPost("update-reservation-state")]
          public async Task<IActionResult> UpdateReservationState([FromQuery] int reservationId, [FromQuery] ReservationState newState)
          {
              var result = await _reservationStateService.UpdateReservationStateAsync(reservationId, newState);
              if (result)
                  return Ok("Starea rezervării a fost actualizată.");
              return NotFound("Rezervarea nu a fost găsită sau eroare la actualizare.");
          }
     }
}
