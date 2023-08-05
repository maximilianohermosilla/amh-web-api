using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class SistemaQuery : ISistemaQuery
    {
        private AmhWebDbContext _context;

        public SistemaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sistema>> GetAll()
        {
            var lista = await _context.Sistema.ToListAsync();
            return lista;
        }

        public async Task<Sistema> GetById(int? id)
        {
            var element = await _context.Sistema.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
