using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.IServices;
using Microsoft.AspNetCore.Mvc;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class ParametroConfiguracionController : ControllerBase
    {
        private readonly IParametroConfiguracionService _service;

        public ParametroConfiguracionController(IParametroConfiguracionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ParametroConfiguracionRequest request)
        {
            try
            {
                var response = await _service.Insert(request);

                if (response.statusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return Created("", response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(ParametroConfiguracionRequest request)
        {
            try
            {
                var response = await _service.Update(request);

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

        [HttpGet("IdSistema/{idSistema}")]
        public async Task<IActionResult> GetAllByIdSistema(int idSistema)
        {
            try
            {
                var response = await _service.GetAllByIdSistema(idSistema);

                if (response.statusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return Ok(response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpGet("{nombre}/{idSistema}")]
        public async Task<IActionResult> GetByNombre(string nombre, int idSistema)
        {
            try
            {
                var response = await _service.GetByNombre(nombre, idSistema);

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
