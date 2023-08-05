using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IBancoQuery
    {
        Task<List<Banco>> GetAll();
        Task<Banco> GetById(int? id);
    }
}
