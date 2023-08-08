using amh_web_api.DTO;
using Application.Interfaces.General.IServices;
using Microsoft.AspNetCore.Http;
using Refit;
using System.Net.Http.Headers;
using System.Text.Json;


namespace Application.Services.General
{
    public class ServerImagesApiService: IServerImagesApiService
    {
        private string? _message;
        private string? _response;
        private int _statusCode;
        private HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _url;

        public ServerImagesApiService(HttpClient httpclient)
        {
            _url = "https://api.imgbb.com/1/upload?key=";
            _apiKey = "69f42d2597e89d6e58fd144e55deabcc";
            _httpClient = httpclient;
        }

        public async Task<ResponseModel> UploadImage(IFormFile file, string id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                var content = new MultipartFormDataContent();
                var imageContent = new StreamContent(file.OpenReadStream());
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
                var imageName = string.Format("{0}_{1}.jpg", id, DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                content.Add(imageContent, "image", imageName);

                var requestUrl = _url + _apiKey;
                var responseApi = await _httpClient.PostAsync(requestUrl, content);
                var responseContent = await responseApi.Content.ReadAsStringAsync();

                var responseContentJsonUrl = JsonDocument.Parse(responseContent).RootElement.GetProperty("data").GetProperty("url");

                var responseUrl = new { link = responseContentJsonUrl };

                _response = JsonSerializer.Serialize(responseUrl);

                if (!responseApi.IsSuccessStatusCode)
                {
                    response.statusCode = (int)responseApi.StatusCode;
                    response.message = "Ha ocurrido un error con el servidor de imagenes";                 
                    response.response = false;

                    return response;
                }

                response.statusCode = 201;
                response.message = "Se ha subido la foto con exito";
                response.response = true;

                return response;

            }
            catch (ApiException apiEx)
            {
                response.statusCode = (int)apiEx.StatusCode;
                response.message = apiEx.Message;
                response.response = false;

                return response;
            }
            catch (Exception)
            {
                response.statusCode = 500;
                response.message = "Error al subir la imagen";
                response.response = false;

                return response;
            }
        }

        public async Task<ResponseModel> DeleteImage(string url)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.response = true;

                return response;
            }
            catch (ApiException apiEx)
            {
                response.statusCode = (int)apiEx.StatusCode;
                response.message = apiEx.Message;
                response.response = false;

                return response;
            }
            catch (Exception)
            {                
                response.statusCode = 500;
                response.message = "Error al subir la imagen";
                response.response = false;

                return response;
            }
        }

        public string GetMessage()
        {
            return _message;
        }

        public JsonDocument GetResponse()
        {
            if (_response == null)
            {
                return JsonDocument.Parse("{}");
            }

            return JsonDocument.Parse(_response);
        }

        public int GetStatusCode()
        {
            return _statusCode;
        }

    }
}

