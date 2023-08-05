using Application.Interfaces.GestorExpedientes.IQueries;
using Domain.Models.GestorExpedientes;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorExpedientes
{
    public class CaratulaQuery : ICaratulaQuery
    {
        private AmhWebDbContext _context;

        public CaratulaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Caratula>> GetAll()
        {
            var lista = await _context.Caratula.ToListAsync();
            return lista;
        }

        public async Task<Caratula> GetById(int? id)
        {
            var element = await _context.Caratula.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
