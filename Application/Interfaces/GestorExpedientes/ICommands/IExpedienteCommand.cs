using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.ICommands
{
    public interface IExpedienteCommand
    {
        Task<Expediente> Insert(Expediente entity);
        Task<Expediente> Update(Expediente entity);
        Task Delete(Expediente entity);
    }
}
