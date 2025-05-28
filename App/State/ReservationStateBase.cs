using Domain.Enum;
using System.Threading.Tasks;

namespace App.State
{
    public abstract class ReservationStateBase
    {
        public abstract Task HandleAsync(Domain.DbModel.Reservation reservation);
    }

    public class NewState : ReservationStateBase
    {
        public override Task HandleAsync(Domain.DbModel.Reservation reservation)
        {
            reservation.State = ReservationState.New;
            Infrastructure.Services.LoggerService.Instance.LogInfo($"Rezervare nouă creată cu ID: {reservation.Id}");
            // Aici poți notifica adminul sau trimite email dacă vrei
            return Task.CompletedTask;
        }
    }

    public class ConfirmedState : ReservationStateBase
    {
        public override Task HandleAsync(Domain.DbModel.Reservation reservation)
        {
            reservation.State = ReservationState.Confirmed;
            Infrastructure.Services.LoggerService.Instance.LogInfo($"Rezervare confirmată cu ID: {reservation.Id}");
            // Exemplu: trimitere email de confirmare către client
            var notificationService = new App.Services.NotificationService();
            notificationService.SendConfirmationEmail("client@email.com", "Rezervare confirmată", $"Rezervarea cu ID {reservation.Id} a fost confirmată.");
            return Task.CompletedTask;
        }
    }

    public class CancelledState : ReservationStateBase
    {
        public override Task HandleAsync(Domain.DbModel.Reservation reservation)
        {
            reservation.State = ReservationState.Cancelled;
            Infrastructure.Services.LoggerService.Instance.LogWarning($"Rezervare anulată cu ID: {reservation.Id}");
            // Exemplu: trimitere email de anulare
            var notificationService = new App.Services.NotificationService();
            notificationService.SendConfirmationEmail("client@email.com", "Rezervare anulată", $"Rezervarea cu ID {reservation.Id} a fost anulată.");
            // Aici poți adăuga logica de eliberare masă
            return Task.CompletedTask;
        }
    }

    public class CompletedState : ReservationStateBase
    {
        public override Task HandleAsync(Domain.DbModel.Reservation reservation)
        {
            reservation.State = ReservationState.Completed;
            Infrastructure.Services.LoggerService.Instance.LogInfo($"Rezervare finalizată cu ID: {reservation.Id}");
            // Exemplu: trimitere email de feedback
            var notificationService = new App.Services.NotificationService();
            notificationService.SendConfirmationEmail("client@email.com", "Rezervare finalizată", $"Rezervarea cu ID {reservation.Id} a fost finalizată. Vă rugăm să ne oferiți feedback!");
            return Task.CompletedTask;
        }
    }
}
