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

        public async Task Delete(Cuenta entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Cuenta> Insert(Cuenta entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Cuenta> Update(Cuenta entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
