using Application.Interfaces.MayiGamesCollection.IQueries;
using Domain.Models.MayiGamesCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiGamesCollection
{
    public class JuegoQuery : IJuegoQuery
    {
        private AmhWebDbContext _context;

        public JuegoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Juego>> GetAll()
        {
            var lista = await _context.Juego.ToListAsync();
            return lista;
        }

        public async Task<Juego> GetById(int? id)
        {
            var element = await _context.Juego.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }

        public async Task<List<Juego>> GetByUsuario(int? idUsuario)
        {
            var element = await _context.Juego.Include(j => j.JuegoPlataformas.Where(m => m.IdUsuario == idUsuario)).ThenInclude(j => j.Plataforma).ToListAsync();
            return element;
        }
    }
}
