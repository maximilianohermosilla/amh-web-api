using amh_web_api.DTO;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    internal interface ICervezaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetAllByType(int tipoMercaderiaId);
        Task<ResponseModel> GetByName(string name);
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(CervezaDTO mercaderia);
        Task<ResponseModel> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
        Task<ResponseModel> Update(CervezaDTO mercaderia, int id);
        Task<ResponseModel> Delete(int id);
        Task<bool> ExisteComandaMercaderia(int id);
    }
}
