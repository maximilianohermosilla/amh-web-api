using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class CategoriaIngresoQuery : ICategoriaIngresoQuery
    {
        private AmhWebDbContext _context;

        public CategoriaIngresoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaIngreso>> GetAll()
        {
            var lista = await _context.CategoriaIngreso.OrderByDescending(c => c.Id).ToListAsync();
            return lista;
        }

        public async Task<CategoriaIngreso> GetById(int? id)
        {
            var element = await _context.CategoriaIngreso.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
