using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class TipoTarjetaQuery : ITipoTarjetaQuery
    {
        private AmhWebDbContext _context;

        public TipoTarjetaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoTarjeta>> GetAll()
        {
            var lista = await _context.TipoTarjeta.ToListAsync();
            return lista;
        }

        public async Task<TipoTarjeta> GetById(int? id)
        {
            var element = await _context.TipoTarjeta.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
