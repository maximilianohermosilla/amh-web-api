using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class SistemaCommand : ISistemaCommand
    {
        private AmhWebDbContext _context;

        public SistemaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Sistema sistema)
        {
            _context.Remove(sistema);
            await _context.SaveChangesAsync();
        }

        public async Task<Sistema> Insert(Sistema sistema)
        {
            _context.Add(sistema);
            await _context.SaveChangesAsync();

            return sistema;
        }

        public async Task<Sistema> Update(Sistema sistema)
        {
            _context.Update(sistema);
            await _context.SaveChangesAsync();

            return sistema;
        }
    }
}
