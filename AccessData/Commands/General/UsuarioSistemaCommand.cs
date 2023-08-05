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

        public async Task Delete(UsuarioSistema usuarioSistema)
        {
            _context.Remove(usuarioSistema);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioSistema> Insert(UsuarioSistema usuarioSistema)
        {
            _context.Add(usuarioSistema);
            await _context.SaveChangesAsync();

            return usuarioSistema;
        }

        public async Task<UsuarioSistema> Update(UsuarioSistema usuarioSistema)
        {
            _context.Update(usuarioSistema);
            await _context.SaveChangesAsync();

            return usuarioSistema;
        }
    }
}
