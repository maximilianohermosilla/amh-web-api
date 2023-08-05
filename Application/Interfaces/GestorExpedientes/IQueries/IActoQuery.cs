using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IQueries
{
    public interface IActoQuery
    {
        Task<List<Acto>> GetAll();
        Task<Acto> GetById(int? id);
    }
}
