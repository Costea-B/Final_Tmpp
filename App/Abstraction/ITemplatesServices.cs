using Domain.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Abstraction
{
     public interface ITemplatesServices
     {
          Task<List<string>> GetTemplates();
          Task CreateTemplates(TemplatesCreateRequest templates);
     }
}
