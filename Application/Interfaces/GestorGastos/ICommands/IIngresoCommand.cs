using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IIngresoCommand
    {
        Task<Ingreso> Insert(Ingreso entity);
        Task<Ingreso> Update(Ingreso entity);
        Task Delete(Ingreso entity);
    }
}
