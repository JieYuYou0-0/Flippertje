using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GhibliFlix
{
    public class MailSender
    {
        public static void SendConfirmationMail(string htmlBody, List<string> emails, string title)
        {
            Menu.Log("Totoro sends a confirmation email (≧◡≦)");
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
        public static void SendReservationEmail(string htmlBody, string mail, string title)
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

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z");

        }
    }
}