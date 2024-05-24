using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class CategoriaGastoQuery : ICategoriaGastoQuery
    {
        private AmhWebDbContext _context;

        public CategoriaGastoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaGasto>> GetAll()
        {
            var lista = await _context.CategoriaGasto.OrderByDescending(c => c.Id).ToListAsync();
            return lista;
        }

        public async Task<CategoriaGasto> GetById(int? id)
        {
            var element = await _context.CategoriaGasto.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
