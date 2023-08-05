using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class TarjetaCommand : ITarjetaCommand
    {
        private AmhWebDbContext _context;

        public TarjetaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Tarjeta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tarjeta> Insert(Tarjeta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Tarjeta> Update(Tarjeta entity)
        {
            throw new NotImplementedException();
        }
    }
}
