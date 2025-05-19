using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Abstraction
{
     public interface ILoginServices
     {
          Task<string> Login(string username, string password);

          Task<IdentityResult> Register(string username, string password);
     }
}
