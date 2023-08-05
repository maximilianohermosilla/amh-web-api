using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IQueries
{
    public interface ICaratulaQuery
    {
        Task<List<Caratula>> GetAll();
        Task<Caratula> GetById(int? id);
    }
}
