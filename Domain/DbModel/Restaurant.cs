using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModel
{
     public class Restaurant
     {
          public int Id { get; set; }
          public string Name { get; set; } = string.Empty;
          public string Address { get; set; } = string.Empty;
          public string Phone { get; set; }

          public ICollection<Reservation> Reservations { get; set; }
     }

}
