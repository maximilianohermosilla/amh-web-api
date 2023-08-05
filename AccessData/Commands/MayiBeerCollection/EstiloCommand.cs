using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class EstiloCommand : IEstiloCommand
    {
        private AmhWebDbContext _context;

        public EstiloCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Estilo estilo)
        {
            throw new NotImplementedException();
        }

        public Task<Estilo> Insert(Estilo estilo)
        {
            throw new NotImplementedException();
        }

        public Task<Estilo> Update(Estilo estilo)
        {
            throw new NotImplementedException();
        }
    }
}
