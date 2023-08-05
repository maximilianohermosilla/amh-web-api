using amh_web_api.DTO;
using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface IRegistroService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(Registro entity);
        Task<ResponseModel> Update(Registro entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
