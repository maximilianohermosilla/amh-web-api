using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface ITipoTarjetaCommand
    {
        Task<TipoTarjeta> Insert(TipoTarjeta entity);
        Task<TipoTarjeta> Update(TipoTarjeta entity);
        Task Delete(TipoTarjeta entity);
    }
}
