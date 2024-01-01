using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IUsuarioSistemaQuery
    {
        Task<List<UsuarioSistema>> GetAll();
        Task<List<UsuarioSistema>> GetBySistema(int idSistema);
        Task<UsuarioSistema> GetByUsuarioSistema(int? idUsuario, int? idSistema);
        Task<UsuarioSistema> GetById(int idUsuarioSistema);
    }
}
