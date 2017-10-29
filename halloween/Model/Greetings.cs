using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace halloween.Model
{

	public class Greetings
	{

        [DisplayName("Sender's name")]
        [Display(Prompt = "First & Last Name")]
        [Required(ErrorMessage = "You must enter something here.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string SenderName { get; set; }

        [DisplayName("Sender's email")]
        [Required(ErrorMessage = "Required")]
        public string SenderEmail { get; set; }

        [DisplayName("Recipient's name")]
        [Display(Prompt = "Recipient's name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string RecipientName { get; set; }

        [DisplayName("Recipient's email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Required")]
        public string RecipientEmail { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "Required")]
        public string Subject { get; set; }

        [DisplayName("Message")]
        [Required(ErrorMessage = "Required")]
        public string Mesg { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Agree { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CreateDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public string CreateIP { get; set; }

        public string SendDate { get; set; }
        public string SendIP { get; set; }

        [Required(ErrorMessage = "Required")]
        public string reCaptcha { get; set; }

    }

}
