using amh_web_api.DTO;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface ICervezaQuery
    {
        Task<List<Cerveza>> GetAll();
        Task<Cerveza> GetById(int? id);
        Task<List<Cerveza>> GetAllFilter(BusquedaDTO busqueda);
    }
}
