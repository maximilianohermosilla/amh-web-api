using Application.Interfaces.GestorExpedientes.IQueries;
using Domain.Models.GestorExpedientes;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorExpedientes
{
    public class ActoQuery : IActoQuery
    {
        private AmhWebDbContext _context;

        public ActoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Acto>> GetAll()
        {
            var lista = await _context.Acto.ToListAsync();
            return lista;
        }

        public async Task<Acto> GetById(int? id)
        {
            var element = await _context.Acto.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
