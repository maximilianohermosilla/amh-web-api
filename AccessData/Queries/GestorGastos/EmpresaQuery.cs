using Application.Interfaces.GestorGastos.IQueries;
using Domain.Models.GestorGastos;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorGastos
{
    public class EmpresaQuery : IEmpresaQuery
    {
        private AmhWebDbContext _context;

        public EmpresaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Empresa>> GetAll()
        {
            var lista = await _context.Empresa.ToListAsync();
            return lista;
        }

        public async Task<Empresa> GetById(int? id)
        {
            var element = await _context.Empresa.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }
    }
}
