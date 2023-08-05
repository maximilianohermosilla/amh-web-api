using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ITipoTarjetaQuery
    {
        Task<List<TipoTarjeta>> GetAll();
        Task<TipoTarjeta> GetById(int? id);
    }
}
