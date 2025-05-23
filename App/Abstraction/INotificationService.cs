using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Abstraction
{
     public interface INotificationService
     {
          void SendConfirmationEmail(string toEmail, string subject, string body);
     }
}
