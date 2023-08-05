using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IBancoCommand
    {
        Task<Banco> Insert(Banco entity);
        Task<Banco> Update(Banco entity);
        Task Delete(Banco entity);
    }
}
