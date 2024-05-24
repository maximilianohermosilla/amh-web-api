using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ICategoriaIngresoQuery
    {
        Task<List<CategoriaIngreso>> GetAll();
        Task<CategoriaIngreso> GetById(int? id);
    }
}
