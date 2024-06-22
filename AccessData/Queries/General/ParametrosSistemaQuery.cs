using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class ParametrosSistemaQuery : IParametrosSistemaQuery
    {
        private AmhWebDbContext _context;

        public ParametrosSistemaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParametrosSistema>> GetAll()
        {
            var lista = await _context.ParametrosSistema.Include(p => p.Sistema).ToListAsync();
            return lista;
        }

        public async Task<ParametrosSistema> GetByIdSistema(int? idSistema)
        {
            var element = await _context.ParametrosSistema.Include(p => p.Sistema).Where(m => m.IdSistema == idSistema).FirstOrDefaultAsync();
            return element;
        }
    }
}
