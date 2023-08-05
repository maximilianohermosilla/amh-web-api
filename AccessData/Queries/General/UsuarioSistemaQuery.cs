using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class UsuarioSistemaQuery : IUsuarioSistemaQuery
    {
        private AmhWebDbContext _context;

        public UsuarioSistemaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioSistema>> GetAll()
        {
            var lista = await _context.UsuarioSistema.ToListAsync();
            return lista;
        }

        public async Task<List<UsuarioSistema>> GetBySistema(int idSistema)
        {
            var lista = await _context.UsuarioSistema.Where(m => m.IdSistema == idSistema).ToListAsync();
            return lista;
        }

        public async Task<UsuarioSistema> GetByUsuarioSistema(int? idUsuario, int? idSistema)
        {
            var element = await _context.UsuarioSistema.Where(m => m.IdUsuario == idUsuario && m.IdSistema == idSistema).FirstOrDefaultAsync();
            return element;
        }
    }
}
