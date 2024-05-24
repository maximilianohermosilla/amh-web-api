using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IIngresoQuery
    {
        Task<List<Ingreso>> GetAll(int idUsuario, string? periodo);
        Task<List<Ingreso>> GetAllByPeriodo(int idUsuario, string? periodo);
        Task<Ingreso> GetById(int? id);

    }
}
