using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroVinculadoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(RegistroVinculado entity);
        Task<ResponseModel> Update(RegistroVinculado entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
