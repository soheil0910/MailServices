using System.Net.Mail;
using System.Net;

namespace MailServices.Services
{
    public class MailService : IMailService
    {


        #region Send

     

        public bool Send(string subject, string message_htmlString, string ToMail)
        {
            return MailService.Email(subject, message_htmlString, ToMail);
        }

        public bool Send(string subject, string message_htmlString)
        {
            return MailService.Email(subject, message_htmlString, null);
        }
        #endregion

        #region SendMail_Static



        public static bool SendMail_Static(string subject, string message_htmlString, string ToMail)
        {
            return MailService.Email(subject, message_htmlString, ToMail);
        }

        public static bool SendMail_Static(string subject, string message_htmlString)
        {

            return MailService.Email(subject, message_htmlString, null);
        }

        #endregion

        private static bool Email(string subject, string htmlString
            , string? to)
        {
            try
            {
                if (to == null || to.Length == 0) { to = "soheil0910line@gmail.com"; }             
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("soheil0910line@gmail.com");
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;                
                smtp.Credentials = new NetworkCredential("soheil0910line@gmail.com", "App_Passwords");//دریافت رمز و جیمیل 
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return true;

                //برای ساخت پسورد جیمیل
                ///https://myaccount.google.com/apppasswords
            }
            catch (Exception ex)
            {

                //نمایش مشکل در کونسول
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n--------------\n\n");
                Console.ResetColor();
                Console.Write("Exception Message:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message + "\n\n");
                Console.ResetColor();
                Console.Write("Exception:");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(ex + "\n\n");
                Console.ResetColor();

                //برای ارسال خطا به جیمیل ادمین
                //MailService.SendMail_Static($"Exception{subject}:", "Exception Message:" +
                //    $"<h1 style=\"color: red;\">{ex.Message} </h1>" + "<br><br>" + "Exception: " +
                //    $"<h1 style=\"color: red;\">{ex.ToString()}</h1> ", "soheil0910line@gmail.com");

              
                return false;

            }
        }


    }
}
