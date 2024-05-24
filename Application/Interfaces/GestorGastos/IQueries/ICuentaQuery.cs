using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ICuentaQuery
    {
        Task<List<Cuenta>> GetAll(int idUsuario);
        Task<Cuenta> GetById(int? id);
    }
}
