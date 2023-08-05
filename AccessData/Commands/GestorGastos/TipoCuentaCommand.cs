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

        public async Task Delete(TipoCuenta entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoCuenta> Insert(TipoCuenta entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TipoCuenta> Update(TipoCuenta entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
