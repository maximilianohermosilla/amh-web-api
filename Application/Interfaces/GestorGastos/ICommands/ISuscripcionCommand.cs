using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface ISuscripcionCommand
    {
        Task<Suscripcion> Insert(Suscripcion entity);
        Task<Suscripcion> Update(Suscripcion entity);
        Task Delete(Suscripcion entity);
    }
}
