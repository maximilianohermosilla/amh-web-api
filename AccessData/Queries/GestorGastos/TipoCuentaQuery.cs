using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class TipoCuentaQuery : ITipoCuentaQuery
    {
        private AmhWebDbContext _context;

        public TipoCuentaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<TipoCuenta>> GetAll()
        {
            var lista = await _context.TipoCuenta.ToListAsync();
            return lista;
        }

        public async Task<TipoCuenta> GetById(int? id)
        {
            var element = await _context.TipoCuenta.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
