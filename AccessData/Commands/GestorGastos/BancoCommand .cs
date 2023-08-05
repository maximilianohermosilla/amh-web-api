using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class BancoCommand : IBancoCommand
    {
        private AmhWebDbContext _context;

        public BancoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Banco entity)
        {
            throw new NotImplementedException();
        }

        public Task<Banco> Insert(Banco entity)
        {
            throw new NotImplementedException();
        }

        public Task<Banco> Update(Banco entity)
        {
            throw new NotImplementedException();
        }
    }
}
