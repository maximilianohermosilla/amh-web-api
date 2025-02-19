using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IServices
{
    public interface IJuegoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(JuegoRequest entity);
        Task<ResponseModel> Update(JuegoRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
