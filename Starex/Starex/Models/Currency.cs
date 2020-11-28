using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Models
{
    public class Currency
    {
      
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UserBalance> UserBalance { get; set; }
    }
}
