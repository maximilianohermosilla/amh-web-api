using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITarjetaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Tarjeta entity);
        Task<ResponseModel> Update(Tarjeta entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
