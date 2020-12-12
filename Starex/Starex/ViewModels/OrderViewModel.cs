using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

		[Required]
		public string Url { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public string ProductSize { get; set; }

		[Required]
		public string ProductColor { get; set; }

		public string Comment { get; set; }

		[Required]
		public decimal Product_Price { get; set; }

		[Required]
		public decimal Cargo_Price { get; set; }

		[Required]
		public decimal PriceResult { get; set; }

		public int CountryId { get; set; }
		public DateTime CreationDate { get; set; }
		public int StatusId { get; set; }
		public string TrackingCode { get; set; }
		public string UserId { get; set; }
	}
}
