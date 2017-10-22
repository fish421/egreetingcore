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
        [Required(ErrorMessage = "Required")]
        public string fromName { get; set; }

        [DisplayName("Sender's email")]
        [Required(ErrorMessage = "Required")]
        public string fromEmail { get; set; }

        [DisplayName("Recipient's name")]
        [Display(Prompt = "Recipient's name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "You must enter between 3 to 100 characters")]
        public string toName { get; set; }

        [DisplayName("Recipient's email")]
        [Display(Prompt = "username@domain.com")]
        [Required(ErrorMessage = "Required")]
        public string toEmail { get; set; }

        [DisplayName("Subject")]
        [Required(ErrorMessage = "Required")]
        public string subject { get; set; }

        [DisplayName("Message")]
        [Required(ErrorMessage = "Required")]
        public string mesg { get; set; }

        [Required(ErrorMessage = "Required")]
        public string agree { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public string createIP { get; set; }

        public string sendDate { get; set; }
        public string sendIP { get; set; }

    }

}
