using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Models
{
    public class UserBalance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Balance { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
