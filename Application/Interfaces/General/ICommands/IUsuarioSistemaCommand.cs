using Domain.Models;

namespace Application.Interfaces.General.ICommands
{
    public interface IUsuarioSistemaCommand
    {
        Task<UsuarioSistema> Insert(UsuarioSistema usuarioSistema);
        Task<UsuarioSistema> Update(UsuarioSistema usuarioSistema);
        Task Delete(UsuarioSistema usuarioSistema);
    }
}
