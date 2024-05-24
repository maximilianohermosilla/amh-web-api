using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ISuscripcionQuery
    {
        Task<List<Suscripcion>> GetAll(int idUsuario, string? periodo);
        Task<Suscripcion> GetById(int? id);
    }
}
