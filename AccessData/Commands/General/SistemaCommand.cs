using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class SistemaCommand : ISistemaCommand
    {
        private AmhWebDbContext _context;

        public SistemaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Sistema sistema)
        {
            throw new NotImplementedException();
        }

        public Task<Sistema> Insert(Sistema sistema)
        {
            throw new NotImplementedException();
        }

        public Task<Sistema> Update(Sistema sistema)
        {
            throw new NotImplementedException();
        }
    }
}
