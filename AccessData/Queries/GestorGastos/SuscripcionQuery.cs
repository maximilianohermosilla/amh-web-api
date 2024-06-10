using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class SuscripcionQuery : ISuscripcionQuery
    {
        private AmhWebDbContext _context;

        public SuscripcionQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Suscripcion>> GetAll(int idUsuario, string? periodo)
        {
            var lista = await _context.Suscripcion.
                Include(m => m.Registros).
                ThenInclude(r => r.Cuenta).
                Include(r => r.Registros).
                ThenInclude(r => r.CategoriaGasto).
                Include(r => r.Registros).
                ThenInclude(r => r.Empresa).
                Where(m => m.IdUsuario == idUsuario &&
                (periodo == null || m.Registros.Any(r => r.Periodo!.Contains(periodo)))
                ).ToListAsync();
            return lista;
        }

        public async Task<Suscripcion> GetById(int? id)
        {
            var element = await _context.Suscripcion.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
