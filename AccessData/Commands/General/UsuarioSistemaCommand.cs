using Application.Interfaces.General.ICommands;
using Domain.Models;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.General
{
    public class UsuarioSistemaCommand : IUsuarioSistemaCommand
    {
        private AmhWebDbContext _context;

        public UsuarioSistemaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(UsuarioSistema usuarioSistema)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioSistema> Insert(UsuarioSistema usuarioSistema)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioSistema> Update(UsuarioSistema usuarioSistema)
        {
            throw new NotImplementedException();
        }
    }
}
