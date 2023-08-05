using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class CaratulaCommand : ICaratulaCommand
    {
        private AmhWebDbContext _context;

        public CaratulaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Caratula entity)
        {
            throw new NotImplementedException();
        }

        public Task<Caratula> Insert(Caratula entity)
        {
            throw new NotImplementedException();
        }

        public Task<Caratula> Update(Caratula entity)
        {
            throw new NotImplementedException();
        }
    }
}
