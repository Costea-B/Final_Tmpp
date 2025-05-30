﻿using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reservation
{
     public class Reservation
     {
          public Guid Id { get; set; }
          public string UserName { get; set; }
          public string RestaurantName { get; set; }
          public decimal? Price { get; set; }
          public ReservationType ReservationType { get; set; }
     }
}
