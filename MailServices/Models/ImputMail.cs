using System.ComponentModel.DataAnnotations;

namespace MailServices.Models
{
    public class ImputMail
    {

        [Required]
        public string subject { get; set; }
        [Required]       
        public string message { get; set; }
        public string? To_Mail { get; set; }
    }
}
