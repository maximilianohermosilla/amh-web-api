using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AccessData;
using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Application.DTO.General;
using Azure.Core;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _service;

        public CiudadController(ICiudadService service)
        {     
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByCountryOrCity(int? PaisId = null, int? CiudadId = null)
        {
            try
            {
                var response = await _service.GetAllByCountryOrCity(PaisId, CiudadId);

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
        public async Task<IActionResult> Insert(CiudadRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre de la ciudad no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la ciudad. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(CiudadRequest request, int id)
        {
            try
            {    
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request, id);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la ciudad exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = "No se pudo actualizar la ciudad" }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre de la ciudad no puede estar vacío" }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }            
        }

        [HttpDelete("{CiudadId}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int CiudadId)
        {
            try
            {
                var response = await _service.Delete(CiudadId);

                if (response != null && response.response != null)
                {
                    return Ok(new { Message = "Se ha eliminado la ciudad exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra la ciudad" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}