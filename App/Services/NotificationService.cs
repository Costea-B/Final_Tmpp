using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.Abstraction;

namespace App.Services
{
     public class NotificationService : INotificationService
     {
          public void SendConfirmationEmail(string toEmail, string subject, string body)
          {
               var smtpClient = new SmtpClient("smtp.gmail.com")
               {
                    Port = 587,
                    Credentials = new NetworkCredential("jora.branxs@gmail.com", "suwa caqd gufi rsvv"),
                    EnableSsl = true,
               };

               var mailMessage = new MailMessage
               {
                    From = new MailAddress("jora.branxs@example.com"),
                    Subject = "aaa",
                    Body = "test",
                    IsBodyHtml = true,
               };
               mailMessage.To.Add(toEmail);

               smtpClient.Send(mailMessage);
               Console.WriteLine($"Email trimis către {toEmail}");
          }
     }

}
