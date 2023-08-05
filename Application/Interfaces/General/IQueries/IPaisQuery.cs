using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IPaisQuery
    {
        Task<IEnumerable<Pais>> GetByMercaderiaId(int mercaderiaId);
    }
}
