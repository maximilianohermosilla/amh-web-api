using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class RegistroVinculadoCommand : IRegistroVinculadoCommand
    {
        private AmhWebDbContext _context;

        public RegistroVinculadoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(RegistroVinculado entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegistroVinculado> Insert(RegistroVinculado entity)
        {
            throw new NotImplementedException();
        }

        public Task<RegistroVinculado> Update(RegistroVinculado entity)
        {
            throw new NotImplementedException();
        }
    }
}
