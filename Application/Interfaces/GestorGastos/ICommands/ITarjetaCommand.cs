using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface ITarjetaCommand
    {
        Task<Tarjeta> Insert(Tarjeta entity);
        Task<Tarjeta> Update(Tarjeta entity);
        Task Delete(Tarjeta entity);
    }
}
