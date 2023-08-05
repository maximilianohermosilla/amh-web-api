using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface ICiudadCommand
    {
        Task<Ciudad> Insert(Ciudad ciudad);
        Task<Ciudad> Update(Ciudad ciudad);
        Task Delete(Ciudad ciudad);
    }
}
