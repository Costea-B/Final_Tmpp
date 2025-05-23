using App.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.NotificationDecorator
{
     // Decorator: Retry
     public class RetryNotificationDecorator : NotificationDecorator
     {
          public RetryNotificationDecorator(INotificationService inner) : base(inner) { }

          public override void SendConfirmationEmail(string toEmail, string subject, string body)
          {
               int attempts = 0;
               bool success = false;
               while (attempts < 3 && !success)
               {
                    try
                    {
                         base.SendConfirmationEmail(toEmail, subject, body);
                         success = true;
                    }
                    catch (Exception ex)
                    {
                         attempts++;
                         Console.WriteLine($"[RETRY] Eroare trimitere email ({attempts}): {ex.Message}");
                         if (attempts >= 3)
                              throw;
                    }
               }
          }
     }
}
