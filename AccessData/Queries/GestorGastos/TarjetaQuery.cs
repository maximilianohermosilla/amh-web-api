using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class TarjetaQuery : ITarjetaQuery
    {
        private AmhWebDbContext _context;

        public TarjetaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarjeta>> GetAll(int idUsuario)
        {
            var lista = await _context.Tarjeta.Where(t => t.IdUsuario == idUsuario).Include(t => t.Banco).Include(t => t.TipoTarjeta).ToListAsync();
            return lista;
        }

        public async Task<Tarjeta> GetById(int? id)
        {
            var element = await _context.Tarjeta.Include(t => t.Banco).Include(t => t.TipoTarjeta).Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
