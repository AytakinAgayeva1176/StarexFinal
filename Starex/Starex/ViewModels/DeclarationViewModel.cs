using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class DeclarationViewModel
    {
		[NotMapped]
        public List<SelectViewModel> ProductsList { get; set; }
		[Required]
		public int CountryId { get; set; }

		[Required]
		public string Shop { get; set; }

		[Required]
		public string ProductType{ get; set; }

        public bool LiquidOrNot { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public decimal ProductPrice { get; set; }

		[MaxLength(120)]
		public string Comment { get; set; }

	
		public string FileName { get; set; }


		//[Required]
		[NotMapped]
		public IFormFile File { get; set; }

		[Required]
		public string DeliveryCode { get; set; }

		[Required]
		public string OrderNumber { get; set; }

		public decimal ShippingPrice { get; set; }
		public decimal ProductWeight { get; set; }
		public int? WarehouseId { get; set; }
		public DateTime DeclarationDate { get; set; }
		public int StatusId { get; set; }
		public string UserId { get; set; }
		public string TrackingCode { get; set; }
    }
}
