using Application.Interfaces.MayiGamesCollection.IQueries;
using Domain.Models.MayiGamesCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiGamesCollection
{
    public class PlataformaQuery : IPlataformaQuery
    {
        private AmhWebDbContext _context;

        public PlataformaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Plataforma>> GetAll()
        {
            var lista = await _context.Plataforma.ToListAsync();
            return lista;
        }

        public async Task<Plataforma> GetById(int? id)
        {
            var element = await _context.Plataforma.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
