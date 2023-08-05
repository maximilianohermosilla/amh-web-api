using Application.Interfaces.MayiBeerCollection.IQueries;
using Domain.Models.MayiBeerCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiBeerCollection
{
    public class MarcaQuery : IMarcaQuery
    {
        private AmhWebDbContext _context;

        public MarcaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Marca>> GetAll()
        {
            var lista = await _context.Marca.ToListAsync();
            return lista;
        }

        public async Task<Marca> GetById(int? id)
        {
            var element = await _context.Marca.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
