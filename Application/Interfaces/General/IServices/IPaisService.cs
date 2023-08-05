using amh_web_api.DTO;
using Application.DTO.General;

namespace Application.Interfaces.General.IServices
{
    public interface IPaisService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(PaisRequest entity);
        Task<ResponseModel> Update(PaisRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
