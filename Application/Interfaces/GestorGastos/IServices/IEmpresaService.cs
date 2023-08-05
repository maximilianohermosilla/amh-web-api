using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IEmpresaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Empresa entity);
        Task<ResponseModel> Update(Empresa entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
