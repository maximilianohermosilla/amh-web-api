using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class SituacionRevistaCommand : ISituacionRevistaCommand
    {
        private AmhWebDbContext _context;

        public SituacionRevistaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(SituacionRevista entity)
        {
            throw new NotImplementedException();
        }

        public Task<SituacionRevista> Insert(SituacionRevista entity)
        {
            throw new NotImplementedException();
        }

        public Task<SituacionRevista> Update(SituacionRevista entity)
        {
            throw new NotImplementedException();
        }
    }
}
