using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface ICancionCommand
    {
        Task<Cancion> Insert(Cancion cancion);
        Task<Cancion> Update(Cancion cancion);
        Task Delete(Cancion cancion);
        Task Reset(List<int> ids);
    }
}
