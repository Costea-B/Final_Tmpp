using App.Abstraction;
using App.NotificationDecorator;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Facede
{

     // Facade cu Decorator aplicat
     public class ReservationFacade
     {
          private readonly ReservationServices _reservationService;
          private readonly INotificationService _notificationService;

          public ReservationFacade(ReservationServices reservation)
          {
               _reservationService = reservation;

               // Compunere Decoratori
               var baseNotification = new NotificationService();
               var loggingDecorator = new LoggingNotificationDecorator(baseNotification);
               var retryDecorator = new RetryNotificationDecorator(loggingDecorator);

               _notificationService = retryDecorator;
          }

          public async void MakeReservation(string clientEmail, DateTime date, int persons, int restaurantId, int reservationTypeId)
          {
              var reservation = new Domain.DbModel.Reservation
              {
                  UserId = clientEmail, // Presupunem că UserId = clientEmail pentru exemplu
                  Date = date,
                  NumberOfGuests = persons,
                  RestaurantId = restaurantId,
                  ReservationTypeId = reservationTypeId,
                  State = Domain.Enum.ReservationState.New
              };
              var success = await _reservationService.CreateReservationAsync(reservation);

              if (success)
              {
                  var subject = "Confirmare Rezervare";
                  var body = $"Rezervarea dvs. pentru {date} a fost confirmată.";
                  _notificationService.SendConfirmationEmail(clientEmail, subject, body);
              }
          }
     }
}
