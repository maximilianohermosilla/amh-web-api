using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ITipoCuentaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(TipoCuentaRequest entity);
        Task<ResponseModel> Update(TipoCuentaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
