using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    public interface IMarcaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(MarcaRequest mercaderia);
        Task<ResponseModel> Update(MarcaRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
    }
}
