using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class RegistroAhorroQuery : IRegistroAhorroQuery
    {
        private AmhWebDbContext _context;

        public RegistroAhorroQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroAhorro>> GetAll(int idUsuario, string? periodo, string? descripcion)
        {
            var lista = await _context.RegistroAhorro.
                Where(r => r.IdUsuario == idUsuario && 
                      (periodo == null || r.Periodo!.Contains(periodo)) &&
                      (descripcion == null || r.Descripcion!.Contains(descripcion))).
                Include(r => r.Cuenta).
                OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<RegistroAhorro> GetById(int? id)
        {
            var element = await _context.RegistroAhorro.Include(r => r.Cuenta).Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
