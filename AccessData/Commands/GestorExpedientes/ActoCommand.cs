using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class ActoCommand : IActoCommand
    {
        private AmhWebDbContext _context;

        public ActoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Acto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Acto> Insert(Acto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Acto> Update(Acto entity)
        {
            throw new NotImplementedException();
        }
    }
}
