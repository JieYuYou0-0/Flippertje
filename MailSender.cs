using System.Net;
using System.Net.Mail;

namespace GhibliFlix
{
    class MailSender
    {
        public static void SendConfirmationEmail(string htmlBody, List<string> emails, string title)
        {
            Menu.Log("Ponyo sends confirmation email");
            var smtpClient = new SmtpClient("smtp.office365.com")// switch from platform; gmail to office365 (via gmail kon niet meer ivm beveiliging voor derde partij)
            {
                Port = 587,
                Credentials = new NetworkCredential("ghibliflix@hotmail.com", "Ghibli123"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ghibliflix@hotmail.com"),
                Subject = "Confirmation Mail",
                Body = htmlBody,
                IsBodyHtml = true
            };

            foreach (var x in emails)
            {
                mailMessage.To.Add(x);
            }
            smtpClient.Send(mailMessage);
        }

        public static void SendVerificationEmail(string htmlBody, string email, string title)
        {
            Menu.Log("Ponyo sends verification email");
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ghibliflix@hotmail.com", "Ghibli123"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ghibliflix@hotmail.com"),
                Subject = "Verfication mail",
                Body = htmlBody,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);
            smtpClient.Send(mailMessage);
        }
    }
}