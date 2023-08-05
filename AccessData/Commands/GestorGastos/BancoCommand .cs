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

        public async Task Delete(Banco entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Banco> Insert(Banco entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Banco> Update(Banco entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
