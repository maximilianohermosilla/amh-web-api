using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IQueries
{
    public interface IJuegoQuery
    {
        Task<List<Juego>> GetAll();
        Task<Juego> GetById(int? id);
    }
}
