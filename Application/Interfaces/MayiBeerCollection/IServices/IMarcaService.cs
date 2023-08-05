using amh_web_api.DTO;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    internal interface IMarcaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(MarcaDTO mercaderia);
        Task<ResponseModel> Update(MarcaDTO mercaderia, int id);
        Task<ResponseModel> Delete(int id);
    }
}
