using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Models
{
    public class Order
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string TrackingCode { get; set; }

		[Required]
		public int? CountryId { get; set; }

		[Required]
		public string Url { get; set; }

		[Required]
		public int Quantity { get; set; }

		[Required]
		public int ProductSize { get; set; }

		[Required]
		public string ProductColor { get; set; }

		public string Comment { get; set; }

		[Required]
		public decimal Product_Price { get; set; }

		[Required]
		public decimal Cargo_Price { get; set; }

		[Required]
		public decimal PriceResult { get; set; }

		[Required]
		public DateTime CreationDate { get; set; }
        public int StatusId { get; set; }
        public string UserId { get; set; }

		public virtual ApplicationUser User { get; set; }
		public virtual OrderStatus Status { get; set; }
		public virtual Country Country { get; set; }

	}
}
