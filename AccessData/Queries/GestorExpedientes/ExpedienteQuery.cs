using Application.Interfaces.GestorExpedientes.IQueries;
using Domain.Models.GestorExpedientes;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.GestorExpedientes
{
    public class ExpedienteQuery : IExpedienteQuery
    {
        private AmhWebDbContext _context;

        public ExpedienteQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expediente>> GetAll()
        {
            var lista = await _context.Expediente.ToListAsync();
            return lista;
        }

        public async Task<Expediente> GetById(int? id)
        {
            var element = await _context.Expediente.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }

        public async Task<List<Expediente>> GetAllPending()
        {
            var lista = (from tbl in _context.Expediente where tbl.Id > 0 && (tbl.EnviadoLaborales == false || tbl.Avisado == false) select tbl).ToList();
            return lista;
        }
    }
}
