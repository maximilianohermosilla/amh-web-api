using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IRegistroVinculadoQuery
    {
        Task<List<RegistroVinculado>> GetAll(int idUsuario, string? periodo);
        Task<RegistroVinculado> GetById(int? id);
    }
}
