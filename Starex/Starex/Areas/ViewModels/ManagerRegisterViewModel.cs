using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class ManagerRegisterViewModel
    {
        public string Id { get; set; }

		[Required]
		[EmailAddress]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "duzgun mail formati example@gmail.com")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }


		[Required]
		[Display(Name = "Şifrə")]
		public string Password { get; set; }

	}
}
