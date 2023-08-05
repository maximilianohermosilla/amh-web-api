namespace amh_web_api.DTO
{
    public class ResponseModel
    {
        public int? statusCode { get; set; }
        public string? message { get; set; }
        public Object? response { get; set; }
    }
}
