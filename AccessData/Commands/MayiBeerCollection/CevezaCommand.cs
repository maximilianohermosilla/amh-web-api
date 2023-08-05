using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class CevezaCommand : ICervezaCommand
    {
        private AmhWebDbContext _context;

        public CevezaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Cerveza cerveza)
        {
            throw new NotImplementedException();
        }

        public Task<Cerveza> Insert(Cerveza cerveza)
        {
            throw new NotImplementedException();
        }

        public Task<Cerveza> Update(Cerveza cerveza)
        {
            throw new NotImplementedException();
        }
    }
}
