using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IUsuarioQuery
    {
        Task<IEnumerable<Usuario>> GetByMercaderiaId(int mercaderiaId);
    }
}
