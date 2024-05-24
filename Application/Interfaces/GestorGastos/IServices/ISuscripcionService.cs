using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ISuscripcionService
    {
        Task<ResponseModel> GetAll(int idUsuario, string? periodo);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(SuscripcionRequest entity);
        Task<ResponseModel> Update(SuscripcionRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
