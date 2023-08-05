using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class CiudadCommand : ICiudadCommand
    {
        private AmhWebDbContext _context;

        public CiudadCommand(AmhWebDbContext context)
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
