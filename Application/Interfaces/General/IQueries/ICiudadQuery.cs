using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.General.IQueries
{
    public interface ICiudadQuery
    {
        Task<IEnumerable<Ciudad>> GetByMercaderiaId(int mercaderiaId);
    }
}
