using Application.Interfaces.General.ICommands;
using Domain.Models.MayiBeerCollection;
using System.ComponentModel.Design;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AccessData.Commands.General
{
    public class CiudadQuery : ICiudadCommand
    {
        private AmhWebDbContext _context;

        public CiudadQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Ciudad ciudad)
        {
            _context.Remove(ciudad);
            await _context.SaveChangesAsync();
        }

        public async Task<Ciudad> Insert(Ciudad ciudad)
        {
            _context.Add(ciudad);
            await _context.SaveChangesAsync();

            return ciudad;
        }

        public async Task<Ciudad> Update(Ciudad ciudad)
        {
            _context.Update(ciudad);
            await _context.SaveChangesAsync();

            return ciudad;
        }
    }
}
