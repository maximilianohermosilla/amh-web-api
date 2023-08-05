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

        public async Task<List<Registro>> GetAll()
        {
            var lista = await _context.Registro.ToListAsync();
            return lista;
        }

        public async Task<Registro> GetById(int? id)
        {
            var element = await _context.Registro.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
