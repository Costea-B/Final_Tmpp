using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModel
{
     public class TableReservation
     {
          public int TableId { get; set; }
          public Table Table { get; set; }

          public int ReservationId { get; set; }
          public Reservation Reservation { get; set; }
     }

}
