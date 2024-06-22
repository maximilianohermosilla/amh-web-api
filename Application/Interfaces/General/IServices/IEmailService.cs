using amh_web_api.DTO;
using Application.DTO.General;

namespace Application.Interfaces.General.IServices
{
    public interface IEmailService
    {
        Task<ResponseModel> SendEmail(EmailRequest email);
    }
}