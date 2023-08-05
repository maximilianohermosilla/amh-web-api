using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class UsuarioCommand : IUsuarioCommand
    {
        private AmhWebDbContext _context;

        public UsuarioCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Insert(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
