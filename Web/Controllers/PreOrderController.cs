using App.Abstraction;
using App.Templates;
using Domain.DbModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreOrderController : ControllerBase
    {
        private readonly IPrototypeTemplate _prototypeTemplate;
        public PreOrderController(IPrototypeTemplate prototypeTemplate)
        {
            _prototypeTemplate = prototypeTemplate;
        }

        [HttpPost("clone-template")]
        public async Task<IActionResult> CloneTemplate([FromQuery] Guid templateId, [FromQuery] string newType = null)
        {
            await _prototypeTemplate.CloneTemplates(templateId, newType);
            return Ok("Template clonat cu succes.");
        }

        [HttpPost("clone-table-from-template")]
        public async Task<IActionResult> CloneTableFromTemplate([FromQuery] Guid templateId, [FromQuery] int restaurantId)
        {
            try
            {
                var table = await _prototypeTemplate.CloneTableFromTemplateAsync(templateId, restaurantId);
                if (table == null) return NotFound("Template inexistent sau invalid.");
                return Ok(table);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-reservation-with-template-table")]
        public async Task<IActionResult> CreateReservationWithTemplateTable([FromQuery] Guid templateId, [FromQuery] DateTime date, [FromQuery] int guests, [FromQuery] string userId, [FromQuery] int restaurantId)
        {
            var reservationId = await _prototypeTemplate.CreateReservationWithTemplateTable(templateId, date, guests, userId, restaurantId);
            if (reservationId == null) return BadRequest("Eroare la creare rezervare sau template invalid.");
            return Ok($"Rezervare creată cu ID: {reservationId}");
        }

        [HttpPost("create-template")]
        public async Task<IActionResult> CreateTemplate([FromBody] Template template)
        {
            if (string.IsNullOrEmpty(template.Type))
                return BadRequest("Type este obligatoriu!");
            if (string.IsNullOrEmpty(template.JsonTemplate))
                return BadRequest("JsonTemplate este obligatoriu!");
            await _prototypeTemplate.CloneTemplates(template.Id, template.Type);
            return Ok("Template creat cu succes.");
        }
    }
}