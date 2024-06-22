using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface IParametrosSistemaCommand
    {
        Task<ParametrosSistema> Insert(ParametrosSistema sistema);
        Task<ParametrosSistema> Update(ParametrosSistema sistema);
        Task Delete(ParametrosSistema sistema);
    }
}
