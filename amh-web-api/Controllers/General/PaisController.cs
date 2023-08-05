using Microsoft.AspNetCore.Mvc;
using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Application.DTO.General;
using Azure.Core;

#nullable disable
namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;

        public PaisController(IPaisService service)
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

        [HttpGet("IdPais")]
        public async Task<IActionResult> GetById(int IdPais)
        {
            try
            {
                var response = await _service.GetById(IdPais);

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
        public async Task<IActionResult> nuevo(PaisRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre del país no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar el país. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(PaisRequest request, int id)
        {
            try
            {
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request, id);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado el pais exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar el pais" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre del pais no puede estar vacío" }) { StatusCode = 400 };
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
                    return Ok(new { Message = "Se ha eliminado el pais exitosamente.", Response = response });
                }

                return new JsonResult(new { Message = "No se encuentra el pais" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}