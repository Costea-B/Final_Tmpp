﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Factory
{
     public interface IReservation
     {
          string Allocate(int guests, string userId, int restaurantId);
     }
}
