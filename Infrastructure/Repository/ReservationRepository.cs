using Domain.DbModel;
using Infrastructure.Abstraction;
using Infrastructure.DbContext;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
               try
               {
                    await _context.AddAsync(reservation);
                    await _context.SaveChangesAsync();
               }
               catch (Exception ex)
               {
                    Console.WriteLine(ex.InnerException?.Message ?? ex.Message);
                    throw;
               }
        }
    }
}
