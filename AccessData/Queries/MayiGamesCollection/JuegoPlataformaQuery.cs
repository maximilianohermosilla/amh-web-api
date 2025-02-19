using Application.Interfaces.MayiGamesCollection.IQueries;
using Domain.Models.MayiGamesCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiGamesCollection
{
    public class JuegoPlataformaQuery : IJuegoPlataformaQuery
    {
        private AmhWebDbContext _context;

        public JuegoPlataformaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<JuegoPlataforma>> GetAll()
        {
            var lista = await _context.JuegoPlataforma.ToListAsync();
            return lista;
        }

        public async Task<JuegoPlataforma> GetById(int? id)
        {
            var element = await _context.JuegoPlataforma.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }  
    }
}
