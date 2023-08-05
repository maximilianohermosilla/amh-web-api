using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface IActoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(ActoRequest entity);
        Task<ResponseModel> Update(ActoRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
