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

          public StandartReservation(ITableAllocationStrategy strategy)
          {
               _strategy = strategy;
          }

          public string Allocate(int guests, string userId, int restaurantId)
          {
               return _strategy.AllocateTable(guests, userId, restaurantId);
          }
     }

     public class VipReservation : IReservation
     {
          private readonly ITableAllocationStrategy _strategy;

          public VipReservation(ITableAllocationStrategy strategy)
          {
               _strategy = strategy;
          }

          public string Allocate(int guests, string userId, int restaurantId)
          {
               return _strategy.AllocateTable(guests, userId, restaurantId);
          }
     }

     public class EventReservation : IReservation
     {
          private readonly ITableAllocationStrategy _strategy;

          public EventReservation(ITableAllocationStrategy strategy)
          {
               _strategy = strategy;
          }

          public string Allocate(int guests, string userId, int restaurantId)
          {
               return _strategy.AllocateTable(guests, userId, restaurantId);
          }
     }


}
