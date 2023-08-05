using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class PaisQuery : IPaisQuery
    {
        private AmhWebDbContext _context;

        public PaisQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pais>> GetAll()
        {
            var lista = await _context.Pais.ToListAsync();
            return lista;
        }

        public async Task<Pais> GetById(int? id)
        {
            var element = await _context.Pais.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
