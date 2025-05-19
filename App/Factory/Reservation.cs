using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Factory
{
     public class StandartReservation : IReservation
     {
     }

     public class FastReservation : IReservation { }

     public class VipReservation : IReservation { }
     public class EventReservation : IReservation { }
}
