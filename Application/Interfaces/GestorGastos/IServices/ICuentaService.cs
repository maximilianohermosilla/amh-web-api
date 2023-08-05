using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ICuentaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(CuentaRequest entity);
        Task<ResponseModel> Update(CuentaRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
