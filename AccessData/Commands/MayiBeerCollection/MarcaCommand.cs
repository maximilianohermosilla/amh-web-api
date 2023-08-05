using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class MarcaCommand : IMarcaCommand
    {
        private AmhWebDbContext _context;

        public MarcaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Marca marca)
        {
            _context.Remove(marca);
            await _context.SaveChangesAsync();
        }

        public async Task<Marca> Insert(Marca marca)
        {
            _context.Add(marca);
            await _context.SaveChangesAsync();

            return marca;
        }

        public async Task<Marca> Update(Marca marca)
        {
            _context.Update(marca);
            await _context.SaveChangesAsync();

            return marca;
        }
    }
}
