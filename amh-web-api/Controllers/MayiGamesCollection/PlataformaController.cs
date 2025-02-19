using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;
using Application.Interfaces.MayiGamesCollection.IServices;
using Microsoft.AspNetCore.Mvc;


namespace amh_web_api.Controllers.GestorExpediente
{
    [Route("[controller]")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaService _service;

        public PlataformaController(IPlataformaService service)
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

        [HttpGet("{Id}")]
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

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert(PlataformaRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre de la plataforma no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la plataforma. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(PlataformaRequest request)
        {
            try
            {
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la plataforma exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar la plataforma" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre de la plataforma no puede estar vacío" }) { StatusCode = 400 };
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
                    return Ok(new { Message = "Se ha eliminado la plataforma exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra la plataforma" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}
