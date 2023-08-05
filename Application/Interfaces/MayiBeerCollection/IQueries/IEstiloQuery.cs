using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface IEstiloQuery
    {
        Task<List<Estilo>> GetAll();
        Task<IEstiloQuery> GetById(int? id);
    }
}
