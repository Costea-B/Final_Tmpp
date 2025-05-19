using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Abstraction
{
     public interface IJwtTokenGenerator
     {
          string GenerateToken(IdentityUser user);
     }
}
