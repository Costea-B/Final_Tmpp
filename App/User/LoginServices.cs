using App.Abstraction;
using Domain.User;
using Microsoft.AspNetCore.Identity;


namespace App.User
{
     public class LoginService : ILoginServices
     {
          private readonly UserManager<IdentityUser> _userManager;
          private readonly SignInManager<IdentityUser> _signInManager;
          private readonly IJwtTokenGenerator _tokenGenerator;

          public LoginService(UserManager<IdentityUser> userManager,
                              SignInManager<IdentityUser> signInManager,
                              IJwtTokenGenerator tokenGenerator)
          {
               _userManager = userManager;
               _signInManager = signInManager;
               _tokenGenerator = tokenGenerator;
          }

          public async Task<string> Login(string email, string password)
          {
               var user = await _userManager.FindByEmailAsync(email);
               if (user == null)
                    throw new UnauthorizedAccessException("Invalid credentials");

               var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
               if (!result.Succeeded)
                    throw new UnauthorizedAccessException("Invalid credentials");

               return _tokenGenerator.GenerateToken(user);
          }

          public async Task<IdentityResult> Register(string email, string password)
          {
               var user = new Users
               {
                    UserName = "Costea",
                    Email = email
               };

               var result = await _userManager.CreateAsync(user, password);

               return result;
          }

     }

}
