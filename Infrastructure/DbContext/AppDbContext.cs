using Domain.DbModel;
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
          public DbSet<Template> Templates { get; set; }

          public DbSet<Restaurant> Restaurants { get; set; }
          public DbSet<Table> Tables { get; set; }
          public DbSet<Reservation> Reservation { get; set; }
          public DbSet<TableReservation> TableReservations { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               base.OnModelCreating(modelBuilder);

               modelBuilder.Entity<TableReservation>()
                   .HasKey(tr => new { tr.TableId, tr.ReservationId });

               modelBuilder.Entity<TableReservation>()
                   .HasOne(tr => tr.Table)
                   .WithMany(t => t.TableReservations)
                   .HasForeignKey(tr => tr.TableId)
                   .OnDelete(DeleteBehavior.Restrict);


          }
     }
}
