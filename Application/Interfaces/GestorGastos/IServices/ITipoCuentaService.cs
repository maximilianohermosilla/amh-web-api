using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITipoCuentaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(TipoCuenta entity);
        Task<ResponseModel> Update(TipoCuenta entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
