using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestDto
{
     public class TemplatesCreateRequest 
     {
          public string Name { get; set; }
          public string Description { get; set; }
          public decimal Price { get; set; }
          public string Type { get; set; } // ex: Lunch, Dinner, etc.
     }
}
