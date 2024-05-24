using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IEmpresaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(EmpresaRequest entity);
        Task<ResponseModel> Update(EmpresaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
