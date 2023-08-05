using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class EmpresaCommand : IEmpresaCommand
    {
        private AmhWebDbContext _context;

        public EmpresaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public Task Delete(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> Insert(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public Task<Empresa> Update(Empresa entity)
        {
            throw new NotImplementedException();
        }
    }
}
