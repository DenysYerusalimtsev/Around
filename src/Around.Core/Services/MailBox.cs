using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Around.Core.Interfaces;

namespace Around.Core.Services
{
    public class MailBox : IMailBox
    {
        public async Task Send(Stream attachment)
        {
            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("ontouragetest@gmail.com", "boulder840")
            };

            using (var message = new MailMessage("ontouragetest@gmail.com", "denis.yerusalimtsev@gmail.com"))
            {
                message.Subject = "Test";
                message.Body = "Body";
                message.Attachments.Add(new Attachment(attachment, "AroundCheque","application/pdf"));
                try
                {
                    await smtpClient.SendMailAsync(message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
