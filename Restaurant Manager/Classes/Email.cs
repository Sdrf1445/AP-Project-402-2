using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Classes
{
    public class Email
    {
        public static int verificationCode {  get; set; }
        
        static int GenerateVerificationCode()
        {
            Random rnd = new Random();
            verificationCode = rnd.Next(1000, 10000);
            return verificationCode;
        }

        public static void SendEmail(string emailAddress, string name)
        {
            var fromAddress = new MailAddress("iustrestaurant811@gmail.com", "IUST Restaurant");
            var toAddress = new MailAddress(emailAddress, name);
            const string fromPassword = "sfuttrvilmjciuxu";
            const string subject = "Verification Code";
            string body = GenerateVerificationCode().ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true, // Enable SSL/TLS
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public static bool Verify(int code)
        {
            if (code == verificationCode) 
            {
                return true;
            }
            return false;
        }
    }
}
