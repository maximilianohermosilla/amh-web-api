using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.ICommands
{
    public interface IJuegoPlataformaCommand
    {
        Task<JuegoPlataforma> Insert(JuegoPlataforma entity);
        Task<JuegoPlataforma> Update(JuegoPlataforma entity);
        Task Delete(JuegoPlataforma entity);
    }
}
