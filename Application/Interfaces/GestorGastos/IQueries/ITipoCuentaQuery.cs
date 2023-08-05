using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface ITipoCuentaQuery
    {
        Task<List<TipoCuenta>> GetAll();
        Task<TipoCuenta> GetById(int? id);
    }
}
