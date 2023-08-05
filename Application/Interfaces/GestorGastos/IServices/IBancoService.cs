using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IBancoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Banco entity);
        Task<ResponseModel> Update(Banco entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
