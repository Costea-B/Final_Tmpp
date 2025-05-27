using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Strategy
{
     public interface ITableAllocationStrategy
     {
          string AllocateTable(int guests, string userId, int restaurantId);
     }
}
