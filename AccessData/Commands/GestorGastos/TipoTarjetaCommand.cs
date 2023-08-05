using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class TipoTarjetaCommand : ITipoTarjetaCommand
    {
        private AmhWebDbContext _context;

        public TipoTarjetaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(TipoTarjeta entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoTarjeta> Insert(TipoTarjeta entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoTarjeta> Update(TipoTarjeta entity)
        {
            throw new NotImplementedException();
        }
    }
}
