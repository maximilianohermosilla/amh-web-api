using amh_web_api.DTO;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IServices
{
    public interface ICaratulaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Caratula entity);
        Task<ResponseModel> Update(Caratula entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
