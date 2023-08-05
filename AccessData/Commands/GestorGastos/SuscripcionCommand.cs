using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class SuscripcionCommand : ISuscripcionCommand
    {
        private AmhWebDbContext _context;

        public SuscripcionCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Suscripcion entity)
        {
            throw new NotImplementedException();
        }

        public Task<Suscripcion> Insert(Suscripcion entity)
        {
            throw new NotImplementedException();
        }

        public Task<Suscripcion> Update(Suscripcion entity)
        {
            throw new NotImplementedException();
        }
    }
}
