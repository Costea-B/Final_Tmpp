using Domain.DbModel;
using Infrastructure.Abstraction;
using Infrastructure.DbContext;
using Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository
{
     public class TemplatesRepository : ITemplatesRepository
     {
          private readonly ILoggerService _logger;
          private readonly AppDbContext _context;
          public TemplatesRepository(ILoggerService logger, AppDbContext dbContext)
          {
               _logger = logger;
               _context = dbContext;
          }
          public async Task Createtempaltes(Template json)
          {
               try
               {
                    if (json is null) return;
                    var template = new Template
                    {
                         JsonTemplate = json.JsonTemplate,
                         Type = json.Type,
                    };
                    await _context.Templates.AddAsync(template);
                    await _context.SaveChangesAsync();
               }
               catch 
               {
                    _logger.LogWarning("eroare la creare template");
               }
          }

          public async Task<List<string>> GetTemplates()
          {
               return await _context.Templates
                             .Select(t => t.JsonTemplate)
                             .ToListAsync();
          }
          public async Task<Template> GetTemplateByIdAsync(Guid id)
          {
              return await _context.Templates.FirstOrDefaultAsync(t => t.Id == id);
          }
     }
}
