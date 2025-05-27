using App.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.NotificationDecorator
{
     public class NotificationDecorator : INotificationService
     {
          protected readonly INotificationService _inner;

          public NotificationDecorator(INotificationService inner)
          {
               _inner = inner;
          }

          public virtual void SendConfirmationEmail(string toEmail, string subject, string body)
          {
               _inner.SendConfirmationEmail(toEmail, subject, body);
          }         
          

     }
}
