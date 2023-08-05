using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface ICervezaQuery
    {
        Task<List<Cerveza>> GetAll();
        Task<List<Cerveza>> GetAllByType(int tipoMercaderiaId);
        Task<Cerveza> GetByName(string nombre);
        Task<Cerveza> GetById(int? id);
        Task<List<Cerveza>> GetByTypeNameOrder(int? tipo, string? nombre, string orden);
    }
}
