using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Models
{
    public class InquiryForm
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int CountryId { get; set; }

        [Required]
        public string Note { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        [Required]
        public string UserId { get; set; }

        public int Statusid { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual FormCategory Category { get; set; }
        public virtual Country Country { get; set; }
        public virtual InquiryFormStatus Status { get; set; }
    }
}
