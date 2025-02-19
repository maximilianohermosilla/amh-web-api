using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IServices
{
    public interface IJuegoPlataformaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(JuegoPlataformaRequest entity);
        Task<ResponseModel> Update(JuegoPlataformaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
