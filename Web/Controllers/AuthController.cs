using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using App.Abstraction;

namespace Web.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class AuthController : ControllerBase
     {
          private readonly ILoginServices _loginService;

          public AuthController(ILoginServices loginService)
          {
               _loginService = loginService;
          }
          [HttpPost("login")]
          public async Task<IActionResult> Login([FromBody] LoginRequest request)
          {
               

               var token = await _loginService.Login(request.Email, request.Password);

               // Setăm cookie-ul
               Response.Cookies.Append("jwt", token, new CookieOptions
               {
                    HttpOnly = true,
                    Secure = true, // true în producție
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
               });

               return Ok();
          }

          [HttpPost]
          public async Task<IActionResult> Register(RegisterRequest request)
          {
               var result = await _loginService.Register(request.Email, request.Password);

               if (!result.Succeeded)
                    return BadRequest(result.Errors);

               return Ok($"User registered successfully{result}");
          }


     }
}
