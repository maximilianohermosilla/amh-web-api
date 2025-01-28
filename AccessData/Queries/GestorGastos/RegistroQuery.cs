using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class RegistroQuery : IRegistroQuery
    {
        private AmhWebDbContext _context;

        public RegistroQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Registro>> GetAll(int idUsuario, string? periodo, int? categoria, bool? pagado)
        {
var lista = await _context.Registro.
                Where(r => r.IdUsuario == idUsuario && 
                      (periodo == null || r.Periodo!.Contains(periodo)) &&
                      (categoria == null || r.IdCategoriaGasto == categoria) &&
                      (pagado == null || r.Pagado == pagado)).
                Include(r => r.Cuenta).Include(r => r.CategoriaGasto).Include(r => r.RegistroVinculado).
                Include(r => r.Empresa).Include(r => r.Suscripcion).
                OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<List<Registro>> GetAllBySuscripcionAndDate(int? idUsuario, int idSuscripcion, DateTime? fechaDesde)
        {
            var lista = await _context.Registro.Where(r => r.IdUsuario == idUsuario && r.IdSuscripcion == idSuscripcion && (fechaDesde == null || r.Fecha >= fechaDesde)).OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<List<Registro>> GetAllByIdRegistroVinculado(int? idUsuario, int idRegistroVinculado)
        {
            var lista = await _context.Registro.Where(r => r.IdUsuario == idUsuario && r.IdRegistroVinculado == idRegistroVinculado).OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<Registro> GetById(int? id)
        {
            var element = await _context.Registro.Include(r => r.Cuenta).Include(r => r.CategoriaGasto).Include(r => r.RegistroVinculado).Include(r => r.Empresa).Include(r => r.Suscripcion).Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
