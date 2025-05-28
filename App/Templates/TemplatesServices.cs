using App.Abstraction;
using Domain.RequestDto;
using Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Domain.DbModel;

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
               var template = new Template()
               {
                    JsonTemplate = JsonSerializer.Serialize(templates),
                    Type = templates.Type,
               };
               await _templatesRepository.Createtempaltes(template);
          }

          public async Task<List<string>> GetTemplates()
          {
               return await _templatesRepository.GetTemplates();
          }
     }
}
