using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class SuscripcionCommand : ISuscripcionCommand
    {
        private AmhWebDbContext _context;

        public SuscripcionCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Suscripcion entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Suscripcion> Insert(Suscripcion entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Suscripcion> Update(Suscripcion entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
