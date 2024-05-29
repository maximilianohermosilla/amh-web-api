using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface IExpedienteService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(ExpedienteRequest entity);
        Task<ResponseModel> Update(ExpedienteRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
