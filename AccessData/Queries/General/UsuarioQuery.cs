using Application.Interfaces.General.IQueries;
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
            var lista = await _context.Usuario.ToListAsync();
            return lista;
        }

        public async Task<Usuario> GetById(int? id)
        {
            var element = await _context.Usuario.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }


        public async Task<Usuario> GetByCredentials(string userName, string password)
        {
            var element = await _context.Usuario.Where(m => m.Login == userName && m.Password == password).FirstOrDefaultAsync();
            return element;
        }
    }
}
