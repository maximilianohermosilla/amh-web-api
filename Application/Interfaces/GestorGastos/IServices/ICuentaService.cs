using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ICuentaService
    {
        Task<ResponseModel> GetAll(int idUsuario);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(CuentaFullRequest entity);
        Task<ResponseModel> Update(CuentaFullRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
