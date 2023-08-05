using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IUsuarioSistemaQuery
    {
        Task<IEnumerable<UsuarioSistema>> GetByMercaderiaId(int mercaderiaId);
    }
}
