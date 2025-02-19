using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IServices
{
    public interface IPlataformaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(PlataformaRequest entity);
        Task<ResponseModel> Update(PlataformaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
