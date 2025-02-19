using Domain.Models.MayiGamesCollection;

namespace Application.Interfaces.MayiGamesCollection.ICommands
{
    public interface IPlataformaCommand
    {
        Task<Plataforma> Insert(Plataforma entity);
        Task<Plataforma> Update(Plataforma entity);
        Task Delete(Plataforma entity);
    }
}
