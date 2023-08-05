using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface IUsuarioCommand
    {
        Task<Usuario> Insert(Usuario usuario);
        Task<Usuario> Update(Usuario usuario);
        Task Delete(Usuario usuario);
    }
}
