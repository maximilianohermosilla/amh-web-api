using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class CuentaQuery : ICuentaQuery
    {
        private AmhWebDbContext _context;

        public CuentaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cuenta>> GetAll(int idUsuario)
        {
            var lista = await _context.Cuenta.Include(t => t.TipoCuenta).Include(t => t.Tarjeta).Where(t => t.IdUsuario == idUsuario).ToListAsync();
            return lista;
        }

        public async Task<Cuenta> GetById(int? id)
        {
            var element = await _context.Cuenta.Include(t => t.TipoCuenta).Include(t => t.Tarjeta).Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
