using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IRegistroVinculadoQuery
    {
        Task<List<RegistroVinculado>> GetAll();
        Task<RegistroVinculado> GetById(int? id);
    }
}
