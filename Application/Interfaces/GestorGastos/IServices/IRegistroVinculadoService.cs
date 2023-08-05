using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroVinculadoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(RegistroVinculadoRequest entity);
        Task<ResponseModel> Update(RegistroVinculadoRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
