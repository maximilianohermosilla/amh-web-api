using AccessData;
using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.IServices;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace amh_web_api.Controllers.GestorGastos
{
    [Route("gestorGastos/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _service;

        public CuentaController(ICuentaService service)
        {
            _service = service;
        }

        [HttpGet]
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


        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert(CuentaFullRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre de la cuenta no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la cuenta. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(CuentaFullRequest request)
        {
            try
            {
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la cuenta exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar la cuenta" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre de la cuenta no puede estar vacío" }) { StatusCode = 400 };
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
                    return Ok(new { Message = "Se ha eliminado la cuenta exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra la cuenta" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}