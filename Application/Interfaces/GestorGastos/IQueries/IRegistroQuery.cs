using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.IQueries
{
    public interface IRegistroQuery
    {
        Task<List<Registro>> GetAll(int idUsuario, string? periodo, int? categoria, bool? pagado);
        Task<Registro> GetById(int? id);
        Task<List<Registro>> GetAllBySuscripcionAndDate(int? idUsuario, int idSuscripcion, DateTime? fechaDesde);
        Task<List<Registro>> GetAllByIdRegistroVinculado(int? idUsuario, int idRegistroVinculado);
    }
}
