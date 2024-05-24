using amh_web_api.DTO;
using Application.Interfaces.GestorGastos.IServices;
using Microsoft.AspNetCore.Mvc;

namespace amh_web_api.Controllers.GestorGastos
{
    [Route("gestorGastos/[controller]")]
    [ApiController]
    public class CategoriaGastoController : ControllerBase
    {
        private readonly ICategoriaGastoService _service;

        public CategoriaGastoController(ICategoriaGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAll();

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

        [HttpGet("IdCategoriaGasto")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                var response = await _service.GetById(Id);

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