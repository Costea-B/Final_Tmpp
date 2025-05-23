using App.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.NotificationDecorator
{
     // Decorator: Logging
     public class LoggingNotificationDecorator : NotificationDecorator
     {
          public LoggingNotificationDecorator(INotificationService inner) : base(inner) { }

          public override void SendConfirmationEmail(string toEmail, string subject, string body)
          {
               Console.WriteLine($"[LOG] Trimitere email către: {toEmail}, Subiect: {subject}");
               base.SendConfirmationEmail(toEmail, subject, body);
          }
     }
}
