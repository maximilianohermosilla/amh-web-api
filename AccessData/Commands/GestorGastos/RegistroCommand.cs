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

        public async Task Delete(Registro entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Registro> Insert(Registro entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Registro> Update(Registro entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
