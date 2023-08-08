using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IServices
{
    public interface ICervezaService
    {
        Task<ResponseModel> GetAll(bool fullresponse, int? IdMarca, int? IdEstilo, int? IdCiudad, int? IdPais);
        Task<ResponseModel> GetById(int? id, bool fullresponse);
        Task<ResponseModel> Insert(CervezaRequest mercaderia);
        Task<ResponseModel> Update(CervezaRequest mercaderia, int id);
        Task<ResponseModel> Delete(int id);
        Task<ResponseModel> GetCountReport();
    }
}
