using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class IngresoQuery : IIngresoQuery
    {
        private AmhWebDbContext _context;

        public IngresoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ingreso>> GetAll(int idUsuario, string? periodo, int? categoria)
        {
            var lista = await _context.Ingreso.Include(i => i.CategoriaIngreso).
                Where(i => i.IdUsuario == idUsuario && 
                      (periodo == null || i.Periodo!.Contains(periodo)) && 
                      (categoria == null || i.IdCategoriaIngreso == categoria)).
                OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<List<Ingreso>> GetAllByPeriodo(int idUsuario, string? periodo, int? categoria)
        {
            var lista = await _context.Ingreso.Include(i => i.CategoriaIngreso).
                Where(i => i.IdUsuario == idUsuario && 
                      (periodo == null || i.Periodo == periodo) &&
                      (categoria == null || i.IdCategoriaIngreso == categoria)).
                      OrderByDescending(r => r.Fecha).ToListAsync();
            return lista;
        }

        public async Task<Ingreso> GetById(int? id)
        {
            var element = await _context.Ingreso.Include(i => i.CategoriaIngreso).Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
