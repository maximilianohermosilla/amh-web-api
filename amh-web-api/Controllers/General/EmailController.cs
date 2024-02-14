using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AccessData;
using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Application.DTO.General;
using System.Configuration;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;
        private readonly IConfiguration _configuration;

        public EmailController(IEmailService service, IConfiguration configuration)
        {     
            _service = service;
            _configuration = configuration;
        }

        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            try
            {
                var from = _configuration.GetSection("ConfigMailDonWeb:from").Value;
                var password = _configuration.GetSection("ConfigMailDonWeb:password").Value;

                if (request.Nombre == "")
                {
                    return BadRequest(new BadRequest { message = "El nombre del remitente no puede estar vacío" });
                }

                var response = await _service.SendEmail(request, from, password);

                if (response.statusCode > 399)
                {
                    return BadRequest(new BadRequest { message = "Ocurrió un error al enviar el correo. Revise los valores ingresados" });
                }

                return Created("", response.message);
            }
            catch (Exception ex)
            {
                return BadRequest(new BadRequest { message = ex.Message });
            }
            
        }
    }
}