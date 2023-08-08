using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface ICervezaQuery
    {
        Task<List<Cerveza>> GetAll(int? IdMarca, int? IdEstilo, int? IdCiudad, int? IdPais, bool fullresponse);
        Task<Cerveza> GetById(int? id, bool fullresponse);
        Task<List<ReporteResponse>> GetCountReport();
    }
}
