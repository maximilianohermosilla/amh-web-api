using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IIngresoService
    {
        Task<ResponseModel> GetAll(int idUsuario, string? periodo, int? categoria);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(IngresoRequest entity);
        Task<ResponseModel> Update(IngresoRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
