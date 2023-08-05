using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.IQueries
{
    public interface IMarcaQuery
    {
        Task<List<Marca>> GetAll();
        Task<Marca> GetById(int? id);
    }
}
