using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            using (var client = new SmtpClient("lra.domns.com", 587))
            {
                client.Credentials = new NetworkCredential("dataprocessing@lra.gov.lr", "Data@2017");
                client.EnableSsl = true;

                using (var message = new MailMessage("dataprocessing@lra.gov.lr", to))
                {
                    message.Subject = subject;
                    message.Body = body;
                    client.Send(message);
                }
            }
        }

        
    }
}
