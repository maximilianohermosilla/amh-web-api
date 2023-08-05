using amh_web_api.DTO;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    internal interface IEstiloService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(EstiloDTO mercaderia);
        Task<ResponseModel> Update(EstiloDTO mercaderia, int id);
        Task<ResponseModel> Delete(int id);
    }
}
