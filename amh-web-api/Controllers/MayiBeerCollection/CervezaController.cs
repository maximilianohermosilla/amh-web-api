using Microsoft.AspNetCore.Mvc;
using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Application.Interfaces.MayiBeerCollection.IServices;

namespace amh_web_api.Controllers.MayiBeerCollection
{
    [Route("[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        private readonly ICervezaService _service;

        public CervezaController(ICervezaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(bool fullresponse = false)
        {
            try
            {
                var response = await _service.GetAll(fullresponse);

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

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int Id, bool fullresponse = false)
        {
            try
            {
                var response = await _service.GetById(Id, fullresponse);

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
        public async Task<IActionResult> Insert(CervezaRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre de la cerveza no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la cerveza. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(CervezaRequest request, int id)
        {
            try
            {
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request, id);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la cerveza exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar la cerveza" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre de la cerveza no puede estar vacío" }) { StatusCode = 400 };
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
                    return Ok(new { Message = "Se ha eliminado la cerveza exitosamente.", Response = response });
                }

                return new JsonResult(new { Message = "No se encuentra la cerveza" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}