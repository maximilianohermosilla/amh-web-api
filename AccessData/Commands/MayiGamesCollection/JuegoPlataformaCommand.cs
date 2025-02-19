using Application.Interfaces.MayiGamesCollection.ICommands;
using Domain.Models.MayiGamesCollection;

namespace AccessData.Commands.MayiGamesCollection
{
    public class JuegoPlataformaCommand : IJuegoPlataformaCommand
    {
        private AmhWebDbContext _context;

        public JuegoPlataformaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(JuegoPlataforma entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<JuegoPlataforma> Insert(JuegoPlataforma entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<JuegoPlataforma> Update(JuegoPlataforma entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
