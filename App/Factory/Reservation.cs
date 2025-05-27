using App.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Factory
{
     public class StandartReservation : IReservation
     {
          private readonly ITableAllocationStrategy _strategy;

          public StandartReservation()
          {
               _strategy = new SimpleAllocationStrategy();
          }

          public string Allocate(int guests)
          {
               return _strategy.AllocateTable(guests);
          }
     }

     public class VipReservation : IReservation
     {
          private readonly ITableAllocationStrategy _strategy;

          public VipReservation()
          {
               _strategy = new VipAllocationStrategy();
          }

          public string Allocate(int guests)
          {
               return _strategy.AllocateTable(guests);
          }
     }

     public class EventReservation : IReservation
     {
          private readonly ITableAllocationStrategy _strategy;

          public EventReservation()
          {
               _strategy = new EventAllocationStrategy();
          }

          public string Allocate(int guests)
          {
               return _strategy.AllocateTable(guests);
          }
     }

}
