using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class CancionQuery : ICancionQuery
    {
        private AmhWebDbContext _context;

        public CancionQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cancion>> GetAll()
        {
            var lista = await _context.Cancion.Where(x => x.Habilitado == true).OrderByDescending(x => x.NombreSolicitante).ToListAsync();
            return lista;
        }

        public async Task<Cancion> GetById(int? id)
        {
            var element = await _context.Cancion.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }

        public async Task<List<Cancion>> GetAllById(List<int> ids)
        {
            var lista = await _context.Cancion.Where(c => ids.Any() && ids.Contains(c.Id)).ToListAsync();
            return lista;
        }
    }
}
