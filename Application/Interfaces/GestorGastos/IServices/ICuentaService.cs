using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ICuentaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Cuenta entity);
        Task<ResponseModel> Update(Cuenta entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
