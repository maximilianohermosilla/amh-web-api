using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class PaisCommand : IPaisCommand
    {
        private AmhWebDbContext _context;

        public PaisCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Pais pais)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> Insert(Pais pais)
        {
            throw new NotImplementedException();
        }

        public Task<Pais> Update(Pais pais)
        {
            throw new NotImplementedException();
        }
    }
}
