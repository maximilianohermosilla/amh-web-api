using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface ISituacionRevistaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(SituacionRevistaRequest entity);
        Task<ResponseModel> Update(SituacionRevistaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
