using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.ICommands
{
    public interface IJuegoCommand
    {
        Task<Juego> Insert(Juego entity);
        Task<Juego> Update(Juego entity);
        Task Delete(Juego entity);
    }
}
