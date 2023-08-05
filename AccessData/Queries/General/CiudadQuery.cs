using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class CiudadQuery : ICiudadQuery
    {
        private AmhWebDbContext _context;

        public CiudadQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ciudad>> GetAll()
        {
            var lista = await _context.Ciudad.Include(c => c.Pais).ToListAsync();
            return lista;
        }

        public async Task<List<Ciudad>> GetAllByCountry(int? idPais)
        {
            var lista = await _context.Ciudad.Where(m => m.IdPais == idPais || idPais == null).Include(c => c.Pais).ToListAsync();
            return lista;
        }

        public async Task<Ciudad> GetById(int? id)
        {
            var element = await _context.Ciudad.Where(m => m.Id == id).Include(c => c.Pais).FirstOrDefaultAsync();
            return element;
        }
    }
}
