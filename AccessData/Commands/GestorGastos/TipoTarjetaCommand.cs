using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class TipoTarjetaCommand : ITipoTarjetaCommand
    {
        private AmhWebDbContext _context;

        public TipoTarjetaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(TipoTarjeta entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoTarjeta> Insert(TipoTarjeta entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TipoTarjeta> Update(TipoTarjeta entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
