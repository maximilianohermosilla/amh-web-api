using Microsoft.AspNetCore.Mvc;
using amh_web_api.DTO;
using Application.Interfaces.General.IServices;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class ParametrosSistemaController : ControllerBase
    {
        private readonly IParametrosSistemaService _service;

        public ParametrosSistemaController(IParametrosSistemaService service)
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

        [HttpGet("IdSistema")]
        public async Task<IActionResult> GetById(int IdSistema)
        {
            try
            {
                var response = await _service.GetByIdSistema(IdSistema);

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

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert(ParametrosSistemaRequest request)
        {
            try
            {
                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar los parámetros del sistema. Revise los valores ingresados" });
                }

                return Created("", response.response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpPut]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Update(ParametrosSistemaRequest request)
        {
            try
            {
                if (request.Host != "")
                {
                    var response = await _service.Update(request);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se han actualizado los parámetros del sistema exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudieron actualizar los parámetros del sistema" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El host no puede estar vacío" }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpDelete("{Id}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var response = await _service.Delete(Id);

                if (response != null && response.response != null)
                {
                    return Ok(new { Message = "Se han eliminado los parámetros del sistema exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentran los parámetros del sistema" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}