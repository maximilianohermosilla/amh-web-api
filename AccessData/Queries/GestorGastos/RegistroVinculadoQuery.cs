using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class RegistroVinculadoQuery : IRegistroVinculadoQuery
    {
        private AmhWebDbContext _context;

        public RegistroVinculadoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVinculado>> GetAll(int idUsuario, string? periodo)
        {
            var lista = await _context.RegistroVinculado.Include(r => r.Registros).
                Where(r => r.IdUsuario == idUsuario &&
                (periodo == null || r.Registros.Any(r => r.Periodo!.Contains(periodo)))
                ).ToListAsync();
            return lista;
        }

        public async Task<RegistroVinculado> GetById(int? id)
        {
            var element = await _context.RegistroVinculado.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
