using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    public interface IEstiloService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(EstiloRequest mercaderia);
        Task<ResponseModel> Update(EstiloRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
    }
}
