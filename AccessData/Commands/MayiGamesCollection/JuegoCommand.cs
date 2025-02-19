using Application.Interfaces.MayiGamesCollection.ICommands;
using Domain.Models.MayiGamesCollection;

namespace AccessData.Commands.MayiGamesCollection
{
    public class JuegoCommand : IJuegoCommand
    {
        private AmhWebDbContext _context;

        public JuegoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Juego entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Juego> Insert(Juego entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Juego> Update(Juego entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
