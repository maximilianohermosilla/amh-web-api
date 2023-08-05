using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class CuentaCommand : ICuentaCommand
    {
        private AmhWebDbContext _context;

        public CuentaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> Insert(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cuenta> Update(Cuenta entity)
        {
            throw new NotImplementedException();
        }
    }
}
