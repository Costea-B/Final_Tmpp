using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
     public interface ITemplatesRepository
     {
          Task Createtempaltes(string json);
          Task<List<string>> GetTemplates();
     }
}
