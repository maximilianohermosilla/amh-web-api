using Application.Interfaces.MayiGamesCollection.ICommands;
using Domain.Models.MayiGamesCollection;

namespace AccessData.Commands.MayiGamesCollection
{
    public class PlataformaCommand : IPlataformaCommand
    {
        private AmhWebDbContext _context;

        public PlataformaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Plataforma entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Plataforma> Insert(Plataforma entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Plataforma> Update(Plataforma entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
