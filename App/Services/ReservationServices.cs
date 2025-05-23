using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class ReservationServices
    {
        public async Task<bool> CreateReservation(string clientEmail, DateTime date, int persons)
        {
            // Logica de rezervare
            Console.WriteLine($"Rezervare creată pentru {clientEmail} la {date} pentru {persons} persoane.");
            return true;
        }
    }
}
