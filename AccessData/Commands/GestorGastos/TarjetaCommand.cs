using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class TarjetaCommand : ITarjetaCommand
    {
        private AmhWebDbContext _context;

        public TarjetaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Tarjeta entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Tarjeta> Insert(Tarjeta entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Tarjeta> Update(Tarjeta entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
