using amh_web_api.DTO;
using Application.Interfaces.General.IQueries;
using Azure.Core;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class UsuarioQuery : IUsuarioQuery
    {
        private AmhWebDbContext _context;

        public UsuarioQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAll()
        {
            var lista = await _context.Usuario.Include(u => u.Perfil).ToListAsync();
            return lista;
        }

        public async Task<Usuario> GetById(int? id)
        {
            var element = await _context.Usuario.Where(m => m.Id == id).Include(u => u.Perfil).FirstOrDefaultAsync();
            return element;
        }

        public async Task<Usuario> GetByIdAndEmail(int? id, string email)
        {
            var element = await _context.Usuario.Where(m => m.Correo == email && m.Id != id && m.Habilitado == true).Include(u => u.Perfil).Include(x => x.UsuariosSistema).ThenInclude(x => x.Sistema).FirstOrDefaultAsync();
            return element;
        }

        public async Task<Usuario> GetByCredentials(UsuarioLoginDTO request)
        {
            var element = await _context.Usuario.Where(m => m.Login == request.Login && m.Password == request.Password).Include(u => u.Perfil).Include(x => x.UsuariosSistema).ThenInclude(x => x.Sistema).FirstOrDefaultAsync();
            return element;
        }
    }
}
