using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface IPaisCommand
    {
        Task<Pais> Insert(Pais pais);
        Task<Pais> Update(Pais pais);
        Task Delete(Pais pais);
    }
}
