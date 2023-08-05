using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class ExpedienteCommand : IExpedienteCommand
    {
        private AmhWebDbContext _context;

        public ExpedienteCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Expediente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Expediente> Insert(Expediente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Expediente> Update(Expediente entity)
        {
            throw new NotImplementedException();
        }
    }
}
