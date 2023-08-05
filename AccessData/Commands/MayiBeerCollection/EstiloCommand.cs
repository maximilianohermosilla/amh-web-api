using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class EstiloCommand : IEstiloCommand
    {
        private AmhWebDbContext _context;

        public EstiloCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Estilo estilo)
        {
            _context.Remove(estilo);
            await _context.SaveChangesAsync();
        }

        public async Task<Estilo> Insert(Estilo estilo)
        {
            _context.Add(estilo);
            await _context.SaveChangesAsync();

            return estilo;
        }

        public async Task<Estilo> Update(Estilo estilo)
        {
            _context.Update(estilo);
            await _context.SaveChangesAsync();

            return estilo;
        }
    }
}
