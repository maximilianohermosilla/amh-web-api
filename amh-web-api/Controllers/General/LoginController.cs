using Microsoft.AspNetCore.Mvc;
using AccessData;
using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Application.DTO.General;
using Domain.Models;
using Application.Helpers;
using Application.UseCases;
using System.Security.Principal;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string secretKey;
        private readonly IUsuarioService _service;
        private readonly ITokenServices _tokenServices;

        public LoginController(IConfiguration config, AmhWebDbContext context, IConfiguration configuration, IUsuarioService service, ITokenServices tokenServices)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            _service = service;
            _tokenServices = tokenServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDTO request)
        {
            try
            {
                var response = await _service.GetByCredentials(request, secretKey);

                if (response.statusCode == 400)
                {
                    return BadRequest(new BadRequest { message = response.message });
                }
                if (response.statusCode == 403)
                {
                    return Unauthorized(new BadRequest { message = response.message });
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UsuarioLoginDTO request)
        {
            try
            {
                if (request.PasswordNew.Length > 4)
                {
                    var response = await _service.UpdatePassword(request);
                    if (response != null && response.response != null)
                    {
                        return new JsonResult(new { Message = "Se ha actualizado el usuario exitosamente.", Response = response }) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(new { Message = response.message }) { StatusCode = response.statusCode };
                    }
                }
                else
                {
                    return new JsonResult(new { Message = "La contraseña debe tener al menos 5 caracteres" }) { StatusCode = 400 };
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
        }
    }
}
