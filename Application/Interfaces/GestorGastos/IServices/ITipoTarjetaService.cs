using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITipoTarjetaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(TipoTarjetaRequest entity);
        Task<ResponseModel> Update(TipoTarjetaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
