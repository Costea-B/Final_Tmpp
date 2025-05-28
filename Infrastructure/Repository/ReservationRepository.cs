using Domain.DbModel;
using Domain.Enum;
using Infrastructure.Abstraction;
using Infrastructure.DbContext;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        public async Task<bool> UpdateReservationStateAsync(int reservationId, ReservationState newState)
        {
            var reservation = await _context.Reservation.FindAsync(reservationId);
            if (reservation == null) return false;
            reservation.State = newState;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _context.Reservation.FindAsync(reservationId);
        }

        public async Task<int?> CreateReservationWithTemplateTableAsync(Guid templateId, DateTime date, int guests, string userId, int restaurantId)
        {
            // Clonează masa predefinită
            var template = await _context.Templates.FirstOrDefaultAsync(t => t.Id == templateId);
            if (template == null) return null;
            var table = System.Text.Json.JsonSerializer.Deserialize<Table>(template.JsonTemplate);
            if (table == null) return null;

            // Setează restaurantul primit ca parametru
            table.RestaurantId = restaurantId;

            // Verifică dacă restaurantul există
            var restaurantExists = await _context.Restaurants.AnyAsync(r => r.Id == restaurantId);
            if (!restaurantExists)
                throw new InvalidOperationException("Restaurantul specificat nu există!");

            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();

            // Creează rezervarea și asociază masa clonată
            var reservation = new Reservation
            {
                Date = date,
                NumberOfGuests = guests,
                UserId = userId,
                RestaurantId = restaurantId,
                ReservationTypeId = 1, // sau alt tip după caz
                State = Domain.Enum.ReservationState.New
            };
            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();

            // Creează legătura între masă și rezervare
            var tableReservation = new TableReservation
            {
                TableId = table.Id,
                ReservationId = reservation.Id
            };
            await _context.TableReservations.AddAsync(tableReservation);
            await _context.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservation.ToListAsync();
        }
    }
}
