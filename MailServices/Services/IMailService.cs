namespace MailServices.Services
{
    public interface IMailService
    {

      public bool Send(string subject, string message_htmlString, string ToMail);
      public bool Send(string subject, string message_htmlString);
       

    }
}
