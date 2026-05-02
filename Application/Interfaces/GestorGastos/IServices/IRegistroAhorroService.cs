using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroAhorroService
    {
        Task<ResponseModel> GetAll(int idUsuario, string? periodo, string? descripcion);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(RegistroAhorroRequest entity);
        Task<ResponseModel> Update(RegistroAhorroRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
