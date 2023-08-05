using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ISuscripcionQuery
    {
        Task<List<Suscripcion>> GetAll();
        Task<Suscripcion> GetById(int? id);
    }
}
