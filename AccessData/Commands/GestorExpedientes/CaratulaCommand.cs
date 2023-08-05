using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class CaratulaCommand : ICaratulaCommand
    {
        private AmhWebDbContext _context;

        public CaratulaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Caratula entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Caratula> Insert(Caratula entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Caratula> Update(Caratula entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
