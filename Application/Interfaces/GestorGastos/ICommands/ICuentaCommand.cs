using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface ICuentaCommand
    {
        Task<Cuenta> Insert(Cuenta entity);
        Task<Cuenta> Update(Cuenta entity);
        Task Delete(Cuenta entity);
    }
}
