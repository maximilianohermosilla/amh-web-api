using Application.Interfaces.General.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.General
{
    public class CiudadQuery : ICiudadCommand
    {
        private AmhWebDbContext _context;

        public CiudadQuery(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> Insert(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> Update(Ciudad ciudad)
        {
            throw new NotImplementedException();
        }
    }
}
