using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface IParametroConfiguracionCommand
    {
        Task<ParametroConfiguracion> Insert(ParametroConfiguracion entity);
        Task<ParametroConfiguracion> Update(ParametroConfiguracion entity);
    }
}
