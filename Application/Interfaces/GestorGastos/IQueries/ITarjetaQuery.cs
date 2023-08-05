using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ITarjetaQuery
    {
        Task<List<Tarjeta>> GetAll();
        Task<Tarjeta> GetById(int? id);
    }
}
