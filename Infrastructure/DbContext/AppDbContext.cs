using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContext
{
     public class AppDbContext : IdentityDbContext<IdentityUser>
     {
          public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
          {
          }

          // poți adăuga și DbSet-uri pentru alte tabele aici
          // public DbSet<Product> Products { get; set; }
     }
}
