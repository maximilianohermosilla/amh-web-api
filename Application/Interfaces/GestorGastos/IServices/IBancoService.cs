using amh_web_api.DTO;
using Application.DTO.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IBancoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(BancoRequest entity);
        Task<ResponseModel> Update(BancoRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
