using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace amh_web_api.Controllers.GestorGastos
{
    [Route("gestorGastos/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ITarjetaService _service;

        public TarjetaController(ITarjetaService service)
        {
            _service = service;
        }

        [HttpGet("IdUsuario")]
        public async Task<IActionResult> GetAll(int IdUsuario)
        {
            try
            {
                var response = await _service.GetAll(IdUsuario);

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

        //[HttpGet("IdTarjeta")]
        //public async Task<IActionResult> GetById(int Id)
        //{
        //    try
        //    {
        //        var response = await _service.GetById(Id);

        //        if (response.statusCode == 400)
        //        {
        //            return BadRequest(new BadRequest { message = response.message });
        //        }
        //        if (response.statusCode == 404)
        //        {
        //            return NotFound(new BadRequest { message = response.message });
        //        }

        //        return Ok(response.response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new BadRequest { message = ex.Message });
        //    }
        //}

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert(TarjetaRequest request)
        {
            try
            {
                if (request.Numero == "")
                {
                    return BadRequest(new BadRequest { message = "El número de la tarjeta no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la tarjeta. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(TarjetaRequest request)
        {
            try
            {
                if (request.Numero != "")
                {
                    var response = await _service.Update(request);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la tarjeta exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar la tarjeta" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El número del tarjeta no puede estar vacío" }) { StatusCode = 400 };
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
                    return Ok(new { Message = "Se ha eliminado el tarjeta exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra la tarjeta" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}