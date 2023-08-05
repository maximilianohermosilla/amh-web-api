using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface ISistemaQuery
    {
        Task<IEnumerable<Sistema>> GetByMercaderiaId(int mercaderiaId);
    }
}
