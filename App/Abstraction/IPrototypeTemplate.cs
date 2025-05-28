using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DbModel;

namespace App.Abstraction
{
    public interface IPrototypeTemplate
    {
        Task CloneTemplates(Guid id, string newType = null);
        Task<Table> CloneTableFromTemplateAsync(Guid templateId, int restaurantId);
        Task<int?> CreateReservationWithTemplateTable(Guid templateId, DateTime date, int guests, string userId, int restaurantId);
    }
}
