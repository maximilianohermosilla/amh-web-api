using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Application.Interfaces.MayiBeerCollection.IServices;
using Microsoft.AspNetCore.Mvc;

namespace amh_web_api.Controllers.MayiBeerCollection
{
    [Route("[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly ICervezaService _service;

        public ReporteController(ICervezaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetReportCount()
        {
            try
            {
                var response = await _service.GetCountReport();

                if (response.statusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }
                if (response.statusCode == 404)
                {
                    return NotFound(new BadRequest { message = response.message });
                }

                return Ok(response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }
    }
}
