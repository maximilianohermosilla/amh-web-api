using amh_web_api.DTO;
using Application.DTO.General;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Application.Interfaces.General.IServices
{
    public interface IServerImagesApiService
    {
        Task<ResponseModel> UploadImage(IFormFile file, string id);
        Task<ResponseModel> DeleteImage(string url);
        JsonDocument GetResponse();
    }
}
