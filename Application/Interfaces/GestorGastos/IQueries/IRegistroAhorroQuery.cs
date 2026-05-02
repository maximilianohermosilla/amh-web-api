using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IRegistroAhorroQuery
    {
        Task<List<RegistroAhorro>> GetAll(int idUsuario, string? periodo, string? descripcion);
        Task<RegistroAhorro> GetById(int? id);
    }
}
