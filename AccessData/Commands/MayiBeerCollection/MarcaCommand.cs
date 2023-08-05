using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class MarcaCommand : IMarcaCommand
    {
        private AmhWebDbContext _context;

        public MarcaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Insert(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Task<Marca> Update(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
