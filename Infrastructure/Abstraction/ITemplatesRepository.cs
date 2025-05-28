using Domain.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Abstraction
{
     public interface ITemplatesRepository
     {
          Task Createtempaltes(Template json);
          Task<List<string>> GetTemplates();
          Task<Template> GetTemplateByIdAsync(Guid id);
     }
}
