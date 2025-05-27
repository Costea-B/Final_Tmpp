using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModel
{
     public class Table
     {
          public int Id { get; set; }
          public int Capacity { get; set; }
          public int RestaurantId { get; set; }
          public Restaurant Restaurant { get; set; }

          public ICollection<TableReservation> TableReservations { get; set; }
     }

}
