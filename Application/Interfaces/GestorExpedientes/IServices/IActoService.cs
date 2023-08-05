using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface IActoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Acto entity);
        Task<ResponseModel> Update(Acto entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
