using App.Facede;
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

          public test(ILoggerService logger, ReservationFacade reservationFacade)
          {
               _logger = logger;
               _reservationFacade = reservationFacade;
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
          public IActionResult MakeReservation([FromQuery] string email, [FromQuery] DateTime date, [FromQuery] int persons)
          {
               _reservationFacade.MakeReservation(email, date, persons);
               return Ok("Rezervarea a fost trimisă.");
          }
     }
}
