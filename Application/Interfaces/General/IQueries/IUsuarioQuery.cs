using amh_web_api.DTO;
using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IUsuarioQuery
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetById(int? id);
        Task<Usuario> GetByCredentials(UsuarioLoginDTO request);
    }
}
