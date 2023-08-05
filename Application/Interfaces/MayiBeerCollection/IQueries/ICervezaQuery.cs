using amh_web_api.DTO;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface ICervezaQuery
    {
        Task<List<Cerveza>> GetAll(bool fullresponse);
        Task<Cerveza> GetById(int? id, bool fullresponse);
        Task<List<Cerveza>> GetAllFilter(BusquedaDTO busqueda, bool fullresponse);
    }
}
