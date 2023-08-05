using amh_web_api.DTO;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Domain.Models.MayiBeerCollection;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Query.MayiBeerCollection
{
    public class CervezaQuery : ICervezaQuery
    {
        private AmhWebDbContext _context;

        public CervezaQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cerveza>> GetAll()
        {
            var lista = await _context.Cerveza.ToListAsync();
            return lista;
        }

        public async Task<Cerveza> GetById(int? id)
        {
            var element = await _context.Cerveza.Where(m => m.Id == id).FirstOrDefaultAsync();
            return element;
        }

        public async Task<List<Cerveza>> GetAllFilter(BusquedaDTO busqueda)
        {
            var lista = await (from tbl in _context.Cerveza where
                                (tbl.IdMarca == busqueda.IdMarca || busqueda.IdMarca == 0) &&
                                (tbl.IdEstilo == busqueda.IdEstilo || busqueda.IdEstilo == 0) &&
                                (tbl.IdCiudad == busqueda.IdCiudad || busqueda.IdCiudad == 0 && busqueda.IdPais == 0 ||
                                busqueda.IdCiudad == 0 && busqueda.IdPais > 0 && 
                                (from tblCiudad in _context.Ciudad where tblCiudad.IdPais == busqueda.IdPais select tblCiudad.Id)
                                .Contains((int)tbl.IdCiudad))select tbl).ToListAsync();
            return lista;
        }
    }
}
