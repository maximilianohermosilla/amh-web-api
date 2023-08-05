using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IEmpresaQuery
    {
        Task<List<Empresa>> GetAll();
        Task<Empresa> GetById(int? id);
    }
}
