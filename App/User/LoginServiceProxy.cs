using App.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;


namespace App.User
{
     public class LoginServiceProxy : ILoginServices
     {
          private readonly ILoginServices _inner;
          private readonly ILogger<LoginServiceProxy> _logger;

          public LoginServiceProxy(ILoginServices inner, ILogger<LoginServiceProxy> logger)
          {
               _inner = inner;
               _logger = logger;
          }

          public async Task<string> Login(string email, string password)
          {
               _logger.LogInformation("Login attempt for {Email} at {Time}", email, DateTime.UtcNow);

               try
               {
                    var token = await _inner.Login(email, password);
                    _logger.LogInformation("Login successful for {Email}", email);
                    return token;
               }
               catch (Exception ex)
               {
                    _logger.LogWarning("Login failed for {Email}: {Message}", email, ex.Message);
                    throw;
               }
          }

          public async Task<IdentityResult> Register(string username, string password)
          {
              return await _inner.Register(username, password);
          }
     }

}
