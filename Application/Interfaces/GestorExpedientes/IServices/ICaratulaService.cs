using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface ICaratulaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(CaratulaRequest entity);
        Task<ResponseModel> Update(CaratulaRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
