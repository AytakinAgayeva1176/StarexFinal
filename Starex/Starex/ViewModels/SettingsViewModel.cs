using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class SettingsViewModel
    {
        public string Id { get; set; }
        [Required]
		[Display(Name = "Ad (ingilis hərflərilə)")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Soyad (ingilis hərflərilə)")]
		public string Surname { get; set; }

		[Required]
		[Display(Name = "Cinsinizi seçin")]
		public string Gender { get; set; }

		[Required]
		[Display(Name = "Doğum tarixi")]
		public DateTime BirthDate { get; set; }

		[Required]
		[Display(Name = "Ünvan")]
		public string Address { get; set; }

		//      [Required]
		//[Display(Name = "Bağlamaları təhvil almaq istədiyiniz filial")]
		public int WarehouseId { get; set; }

		[Required]
		public string GovIdPrefix { get; set; }
		[Required]
		[Display(Name = "Şəxsiyyət vəsiqəsinin seriya və nömrəsi")]
		public string GovId { get; set; }

		[Required]
		[StringLength(7)]
		[Display(Name = "FIN Kod")]
		public string FinCode { get; set; }

		[Required]
		[RegularExpression("([+994]{4})[- ]?([50,51,55,70,77]{2})[- ]?([0-9]{3})[- ]?([0-9]{2})[- ]?([0-9]{2})", ErrorMessage = "Duzgun telefon nomresi +994XXXXXXXXX")]
		[Display(Name = "Telefon")]
		public string PhoneNumber { get; set; }

		[Required]
		[EmailAddress]
		[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "duzgun mail formati example@gmail.com")]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Şifrə")]
		public string Password { get; set; }

		[Required]
		[NotMapped]
		[DataType(DataType.Password)]
		[Display(Name = "Şifrənin təkrarı")]
		[Compare("Password", ErrorMessage = "Password doesn't match.")]
		public string ConfirmPassword { get; set; }
	}
}
