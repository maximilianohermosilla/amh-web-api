using amh_web_api.DTO;
using Application.DTO.General;

namespace Application.Interfaces.General.IServices
{
    public interface ICancionService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> Insert(CancionRequest entity);
        Task<ResponseModel> Update(CancionRequest entity);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> Reset(List<int> ids);
    }
}
