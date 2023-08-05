using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface ISituacionRevistaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(SituacionRevista entity);
        Task<ResponseModel> Update(SituacionRevista entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
