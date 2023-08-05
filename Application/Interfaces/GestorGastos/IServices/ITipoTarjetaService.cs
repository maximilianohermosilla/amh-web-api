using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITipoTarjetaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(TipoTarjeta entity);
        Task<ResponseModel> Update(TipoTarjeta entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
