using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IQueries
{
    public interface IPlataformaQuery
    {
        Task<List<Plataforma>> GetAll();
        Task<Plataforma> GetById(int? id);
    }
}
