using Application.Interfaces.MayiBeerCollection.ICommands;
using Domain.Models.MayiBeerCollection;

namespace AccessData.Commands.MayiBeerCollection
{
    public class CervezaCommand : ICervezaCommand
    {
        private AmhWebDbContext _context;

        public CervezaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Cerveza cerveza)
        {
            _context.Remove(cerveza);
            await _context.SaveChangesAsync();
        }

        public async Task<Cerveza> Insert(Cerveza cerveza)
        {
            _context.Add(cerveza);
            await _context.SaveChangesAsync();

            return cerveza;
        }

        public async Task<Cerveza> Update(Cerveza cerveza)
        {
            _context.Update(cerveza);
            await _context.SaveChangesAsync();

            return cerveza;
        }
    }
}
