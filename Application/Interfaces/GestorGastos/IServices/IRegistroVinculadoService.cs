using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroVinculadoService
    {
        Task<ResponseModel> GetAll(int idUsuario, string? periodo);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(RegistroVinculadoRequest entity);
        Task<ResponseModel> Update(RegistroVinculadoRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
