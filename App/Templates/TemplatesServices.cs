using App.Abstraction;
using Domain.RequestDto;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace App.Templates
{
     public class TemplatesServices : ITemplatesServices
     {
          private readonly ITemplatesRepository _templatesRepository;
          public TemplatesServices(ITemplatesRepository templatesRepository)
          {
               _templatesRepository = templatesRepository;
          }
          public async Task CreateTemplates(TemplatesCreateRequest templates)
          {
               string json = JsonSerializer.Serialize(templates);
               await _templatesRepository.Createtempaltes(json);
          }

          public async Task<List<string>> GetTemplates()
          {
               return await _templatesRepository.GetTemplates();
          }
     }
}
