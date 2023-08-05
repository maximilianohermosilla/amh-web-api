using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ISuscripcionService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Suscripcion entity);
        Task<ResponseModel> Update(Suscripcion entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
