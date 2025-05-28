using App.Abstraction;
using Infrastructure.Abstraction;
using Infrastructure.Repository;
using Domain.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Templates
{
    public class TemplatePrototype : IPrototypeTemplate
    {
        private readonly ITemplatesRepository _templatesRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IReservationRepository _reservationRepository;
        public TemplatePrototype(ITemplatesRepository templatesRepository, ITableRepository tableRepository, IReservationRepository reservationRepository)
        {
            _templatesRepository = templatesRepository;
            _tableRepository = tableRepository;
            _reservationRepository = reservationRepository;
        }
        public async Task CloneTemplates(Guid id, string newType = null)
        {
            var original = await _templatesRepository.GetTemplateByIdAsync(id);
            if (original == null) return;
            var clone = new Template
            {
                JsonTemplate = original.JsonTemplate,
                Type = newType ?? original.Type
            };
            await _templatesRepository.Createtempaltes(clone);
        }

        public async Task<Table> CloneTableFromTemplateAsync(Guid templateId, int restaurantId)
        {
            var template = await _templatesRepository.GetTemplateByIdAsync(templateId);
            if (template == null) return null;
            var table = System.Text.Json.JsonSerializer.Deserialize<Table>(template.JsonTemplate);
            if (table == null) return null;

            // Setează restaurantul primit ca parametru
            table.RestaurantId = restaurantId;

            // Verifică dacă restaurantul există
            var restaurantExists = await _tableRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
                throw new InvalidOperationException("Restaurantul specificat nu există!");

            await _tableRepository.AddTableAsync(table);
            return table;
        }

        // Exemplu de utilizare în rezervare:
        // La crearea unei rezervări, poți clona masa predefinită (template) și o poți asocia rezervării
        public async Task<int?> CreateReservationWithTemplateTable(Guid templateId, DateTime date, int guests, string userId, int restaurantId)
        {
            return await _reservationRepository.CreateReservationWithTemplateTableAsync(templateId, date, guests, userId, restaurantId);
        }
    }
}
