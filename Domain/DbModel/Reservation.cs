using Domain.Enum;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbModel
{
     public class Reservation
     {
          public int Id { get; set; }

          public DateTime Date { get; set; }
          public int NumberOfGuests { get; set; }

          public string UserId { get; set; }
          public Users User { get; set; }

          public int ReservationTypeId { get; set; }
          public ReservationType ReservationType { get; set; }

          public int RestaurantId { get; set; }
          public Restaurant Restaurant { get; set; }

          public ReservationState State { get; set; } = ReservationState.New;
     }

}
