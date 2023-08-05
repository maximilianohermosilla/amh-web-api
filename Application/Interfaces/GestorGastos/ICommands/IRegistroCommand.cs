using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IRegistroCommand
    {
        Task<Registro> Insert(Registro entity);
        Task<Registro> Update(Registro entity);
        Task Delete(Registro entity);
    }
}
