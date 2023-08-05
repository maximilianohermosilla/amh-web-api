using Application.Interfaces.MayiBeerCollection.IQueries;
using Domain.Models.MayiBeerCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiBeerCollection
{
    public class EstiloQuery : IEstiloQuery
    {
        private AmhWebDbContext _context;

        public EstiloQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estilo>> GetAll()
        {
            var lista = await _context.Estilo.ToListAsync();
            return lista;
        }

        public async Task<Estilo> GetById(int? id)
        {
            var element = await _context.Estilo.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
