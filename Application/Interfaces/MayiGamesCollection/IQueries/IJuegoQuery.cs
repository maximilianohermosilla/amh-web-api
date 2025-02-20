using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.IQueries
{
    public interface IJuegoQuery
    {
        Task<List<Juego>> GetAll();
        Task<List<Juego>> GetByUsuario(int? idUsuario);
        Task<Juego> GetById(int? id);
    }
}
