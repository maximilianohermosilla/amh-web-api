using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class BancoQuery : IBancoQuery
    {
        private AmhWebDbContext _context;

        public BancoQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Banco>> GetAll()
        {
            var lista = await _context.Banco.ToListAsync();
            return lista;
        }

        public async Task<Banco> GetById(int? id)
        {
            var element = await _context.Banco.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
