using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroService
    {
        Task<ResponseModel> GetAll(int idUsuario, string? periodo, int? categoria, bool? pagado);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(RegistroRequest entity);
        Task<ResponseModel> Update(RegistroRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
