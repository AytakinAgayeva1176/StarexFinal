using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string UserCode { get; set; }
        public string GovIdPrefix { get; set; }
        public string GovId { get; set; }

        [StringLength(7)]
        public string FinCode { get; set; }

        public int? WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public ICollection<UserBalance> UserBalance { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Declaration> Declarations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
