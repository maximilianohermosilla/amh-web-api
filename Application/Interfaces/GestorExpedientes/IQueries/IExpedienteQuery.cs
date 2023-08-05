using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IQueries
{
    public interface IExpedienteQuery
    {
        Task<List<Expediente>> GetAll();
        Task<Expediente> GetById(int? id);
        Task<List<Expediente>> GetAllPending();
    }
}
