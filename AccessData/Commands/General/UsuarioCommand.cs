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

        public async Task Delete(Usuario usuario)
        {
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> Insert(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> Update(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
