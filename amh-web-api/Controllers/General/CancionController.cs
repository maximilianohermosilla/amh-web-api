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
    public class CancionController : ControllerBase
    {
        private readonly ICancionService _service;

        public CancionController(ICancionService service)
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

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Insert(CancionRequest request)
        {
            try
            {
                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre de la canción no puede estar vacío" });
                }

                var response = await _service.Insert(request);

                if (response.response == null)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al insertar la canción. Revise los valores ingresados" });
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
        public async Task<IActionResult> Update(CancionRequest request)
        {
            try
            {    
                if (request.Nombre != "")
                {
                    var response = await _service.Update(request);
                    if (response != null && response.response != null && response.statusCode == 200)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado la canción exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = response.message }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "El nombre de la canción no puede estar vacío" }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }            
        }

        [HttpPatch]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ResetSolicitante(List<int> ids)
        {
            try
            {
                if (ids.Any())
                {
                    var response = await _service.Reset(ids);
                    if (response != null && response.statusCode == 200)
                    {
                        return new JsonResult(new { Message = response.message, Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = response.message }) { StatusCode = 400 };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "No se ingresaron canciones para actualizar" }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }

        [HttpDelete("{CancionId}")]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int CancionId)
        {
            try
            {
                var response = await _service.Delete(CancionId);

                if (response != null && response.response != null)
                {
                    return Ok(new { Message = "Se ha eliminado la canción exitosamente.", Response = response });
                }

                if (response != null && response.statusCode >= 400 && response.statusCode < 500)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }

                return new JsonResult(new { Message = "No se encuentra la canción" }) { StatusCode = 404 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}