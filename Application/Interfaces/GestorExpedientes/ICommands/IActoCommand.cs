using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.ICommands
{
    public interface IActoCommand
    {
        Task<Acto> Insert(Acto entity);
        Task<Acto> Update(Acto entity);
        Task Delete(Acto entity);
    }
}
