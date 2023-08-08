using Application.Interfaces.General.IServices;
using Application.Services.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace amh_web_api.Controllers.General
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IServerImagesApiService _service;

        public ImageController(IServerImagesApiService service)
        {
            _service = service;
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddImage(IFormFile file, string id)
        {
            try
            {                
                var response = await _service.UploadImage(file, id);

                bool uploadIsValid = (bool)response.response;

                if (!uploadIsValid)
                {
                    return new JsonResult(new { Message = response.message, Response = response.response }) { StatusCode = response.statusCode };
                }
                var url = _service.GetResponse().RootElement.GetProperty("link").ToString();

                return new JsonResult(new { Message = "La foto se ha subido correctamente", Response = url }) { StatusCode = 201 };


            }
            catch (Exception)
            {
                return new JsonResult(new { Message = "Se ha producido un error interno en el servidor." }) { StatusCode = 500 };
            }
        }
    }
}
