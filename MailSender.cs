using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace GhibliFlix
{
    internal class MailSender
    {
        internal static void SendConfirmationMail(string htmlBody, List<string> emails, string title)
        {
            Menu.Log("Totoro sends confirmation email");
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ghibliflix@gmail.com", "Ghibli123"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ghibliflix@gmail.com"),
                Subject = title,
                Body = htmlBody,
                IsBodyHtml = true
            };

            foreach (var x in emails)
            {
                mailMessage.To.Add(x);
            }
        }
        internal static void SendVerificationEmail(string htmlBody, string mail, string title)
        {
            Menu.Log("Totoro sends verification mail");
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ghibliflix@gmail.com", "Ghibli123"),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ghibliflix@gmail.com"),
                Subject = title,
                Body = htmlBody,
                IsBodyHtml = true
            };

            mailMessage.To.Add(mail);

            smtpClient.Send(mailMessage);
        }

    }
}