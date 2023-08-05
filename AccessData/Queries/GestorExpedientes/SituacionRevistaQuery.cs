using Application.Interfaces.GestorExpedientes.IQueries;
using Domain.Models.GestorExpedientes;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorExpedientes
{
    public class SituacionRevistaQuery : ISituacionRevistaQuery
    {
        private AmhWebDbContext _context;

        public SituacionRevistaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<SituacionRevista>> GetAll()
        {
            var lista = await _context.SituacionRevista.ToListAsync();
            return lista;
        }

        public async Task<SituacionRevista> GetById(int? id)
        {
            var element = await _context.SituacionRevista.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
