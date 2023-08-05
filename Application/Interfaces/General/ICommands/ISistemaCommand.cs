using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface ISistemaCommand
    {
        Task<Sistema> Insert(Sistema sistema);
        Task<Sistema> Update(Sistema sistema);
        Task Delete(Sistema sistema);
    }
}
