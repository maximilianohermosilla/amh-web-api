using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    public interface ICervezaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetAllByType(int tipoMercaderiaId);
        Task<ResponseModel> GetByName(string name);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(CervezaRequest mercaderia);
        Task<ResponseModel> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
        Task<ResponseModel> Update(CervezaRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
        Task<bool> ExisteComandaMercaderia(int id);
    }
}
