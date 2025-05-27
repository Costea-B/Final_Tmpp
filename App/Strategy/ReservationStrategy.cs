using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Strategy
{
     public class SimpleAllocationStrategy : ITableAllocationStrategy
     {
          public string AllocateTable(int guests)
          {
               return $"Alocare simplă pentru {guests} persoane.";
          }
     }

     public class VipAllocationStrategy : ITableAllocationStrategy
     {
          public string AllocateTable(int guests)
          {
               return $"Alocare specială VIP pentru {guests} persoane.";
          }
     }

     public class EventAllocationStrategy : ITableAllocationStrategy
     {
          public string AllocateTable(int guests)
          {
               return $"Alocare pentru eveniment – grup de {guests} persoane.";
          }
     }

}
