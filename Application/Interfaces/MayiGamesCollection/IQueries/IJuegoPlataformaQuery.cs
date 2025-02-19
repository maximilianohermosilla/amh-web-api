using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IQueries
{
    public interface IJuegoPlataformaQuery
    {
        Task<List<JuegoPlataforma>> GetAll();
        Task<JuegoPlataforma> GetById(int? id);
    }
}
