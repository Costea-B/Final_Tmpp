using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Facede
{
     public class ReservationFacade
     {
          private readonly ReservationServices _reservationService;
          private readonly NotificationService _notificationService;

          public ReservationFacade()
          {
               _reservationService = new ReservationServices();
               _notificationService = new NotificationService();
          }

          public async void MakeReservation(string clientEmail, DateTime date, int persons)
          {
               var success = await _reservationService.CreateReservation(clientEmail, date, persons);

               if (success)
               {
                    var subject = "Confirmare Rezervare";
                    var body = $"Rezervarea dvs. pentru {date} a fost confirmată.";
                    _notificationService.SendConfirmationEmail(clientEmail, subject, body);
               }
          }
     }
}
