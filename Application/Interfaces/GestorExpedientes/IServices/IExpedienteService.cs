using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface IExpedienteService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Expediente entity);
        Task<ResponseModel> Update(Expediente entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
