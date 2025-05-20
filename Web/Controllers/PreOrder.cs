using App.Abstraction;
using Domain.RequestDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Web.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class PreOrder : ControllerBase
     {
          private readonly ITemplatesServices _templatesServices;
          public PreOrder(ITemplatesServices templatesServices)
          {
               _templatesServices = templatesServices;
          }
          [HttpGet]
          public async Task<IActionResult> GetTemplates()
          {
               List<string> jsonList = await _templatesServices.GetTemplates();               
               string jsonArray = "[" + string.Join(",", jsonList) + "]";

               return new ContentResult
               {
                    Content = jsonArray,
                    ContentType = "application/json",
                    StatusCode = 200
               };
          }

          [HttpPost("CreateTemplates")]
          public async Task<IActionResult> CreateTemplates([FromBody] TemplatesCreateRequest templates)
          {
               await _templatesServices.CreateTemplates(templates);
               return Ok();
          }
     }
}
