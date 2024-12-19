using MailServices.Models;
using MailServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;

namespace MailServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        //میل سرویس اینجکت شده
        private readonly IMailService _mailService;
        public SendMailController(IMailService mailService)
        {
            _mailService = mailService;
        }



        [HttpPost]
        public IActionResult SendMail([FromBody] ImputMail data)
        {
            bool result; 


            //ارسال پیام برای ادمین
            if (data.To_Mail == "string" || data.To_Mail == null || data.To_Mail.Length == 0)
            {
                result = _mailService.Send(data.subject, data.message);
            }
            else
            {
                //ارسال پیام به جیمیل دریافت شده از سوی کاربر
                result = _mailService.Send(data.subject, data.message, data.To_Mail);

            }


            return Ok(result);

            //میل سرویس را میتوان به صورت استاتیک هم استفاده کرد 
            //MailService.SendMail_Static()

        }
    }
}
