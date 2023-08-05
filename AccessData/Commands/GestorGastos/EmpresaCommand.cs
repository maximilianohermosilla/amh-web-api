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

        public async Task Delete(Empresa entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Empresa> Insert(Empresa entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Empresa> Update(Empresa entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
