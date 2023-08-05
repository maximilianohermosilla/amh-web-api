using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class TipoCuentaCommand : ITipoCuentaCommand
    {
        private AmhWebDbContext _context;

        public TipoCuentaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(TipoCuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoCuenta> Insert(TipoCuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<TipoCuenta> Update(TipoCuenta entity)
        {
            throw new NotImplementedException();
        }
    }
}
