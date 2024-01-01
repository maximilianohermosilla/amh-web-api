using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.IServices;
using Microsoft.AspNetCore.Mvc;


namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioSistemaController : ControllerBase
    {
        private readonly IUsuarioSistemaService _service;

        public UsuarioSistemaController(IUsuarioSistemaService service)
        {
            _service = service;
        }

        [HttpGet("IdUsuarioSistema")]
        public async Task<IActionResult> GetById(int IdUsuarioSistema)
        {
            try
            {
                var response = await _service.GetById(IdUsuarioSistema);

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
        public async Task<IActionResult> Insert(UsuarioSistemaRequest request)
        {
            try
            {
                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar el registro. Revise los valores ingresados" });
                }

                return Created("", response.response);
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
                    return Ok(new { Message = "Se ha eliminado el registro exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra el registro" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}