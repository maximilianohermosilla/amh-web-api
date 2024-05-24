using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ICategoriaGastoQuery
    {
        Task<List<CategoriaGasto>> GetAll();
        Task<CategoriaGasto> GetById(int? id);
    }
}
