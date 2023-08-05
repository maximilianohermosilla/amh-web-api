using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.ICommands
{
    public interface ICaratulaCommand
    {
        Task<Caratula> Insert(Caratula entity);
        Task<Caratula> Update(Caratula entity);
        Task Delete(Caratula entity);
    }
}
