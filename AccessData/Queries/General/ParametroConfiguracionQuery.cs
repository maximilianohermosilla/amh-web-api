using Application.Interfaces.General.IQueries;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.General
{
    public class ParametroConfiguracionQuery : IParametroConfiguracionQuery
    {
        private readonly AmhWebDbContext _context;

        public ParametroConfiguracionQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParametroConfiguracion>> GetAllByIdSistema(int idSistema)
        {
            return await _context.ParametroConfiguracion.Where(x => x.IdSistema == idSistema).ToListAsync();
        }

        public async Task<ParametroConfiguracion> GetById(int id)
        {
            return await _context.ParametroConfiguracion.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ParametroConfiguracion> GetByNombre(string nombre, int idSistema)
        {
            return await _context.ParametroConfiguracion.FirstOrDefaultAsync(x => x.Nombre == nombre && x.IdSistema == idSistema);
        }
    }
}
