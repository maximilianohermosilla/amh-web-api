using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class RegistroCommand : IRegistroCommand
    {
        private AmhWebDbContext _context;

        public RegistroCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Registro entity)
        {
            throw new NotImplementedException();
        }

        public Task<Registro> Insert(Registro entity)
        {
            throw new NotImplementedException();
        }

        public Task<Registro> Update(Registro entity)
        {
            throw new NotImplementedException();
        }
    }
}
