using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface ITipoCuentaCommand
    {
        Task<TipoCuenta> Insert(TipoCuenta entity);
        Task<TipoCuenta> Update(TipoCuenta entity);
        Task Delete(TipoCuenta entity);
    }
}
