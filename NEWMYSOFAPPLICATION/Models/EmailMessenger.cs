using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace NEWMYSOFAPPLICATION.Models
{
    public class EmailMessenger
    {
        public void sendEmail(String toEmail, String Title, String Msg)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("AOU.Staff.sa@gmail.com", "aou-2020");
            MailMessage mm = new MailMessage("AOU.Staff.sa@gmail.com", toEmail, Title, Msg);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.Send(mm);
        }
    }
}