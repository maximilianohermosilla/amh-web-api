using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class ParametrosSistemaCommand : IParametrosSistemaCommand
    {
        private AmhWebDbContext _context;

        public ParametrosSistemaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(ParametrosSistema sistema)
        {
            _context.Remove(sistema);
            await _context.SaveChangesAsync();
        }

        public async Task<ParametrosSistema> Insert(ParametrosSistema sistema)
        {
            _context.Add(sistema);
            await _context.SaveChangesAsync();

            return sistema;
        }

        public async Task<ParametrosSistema> Update(ParametrosSistema sistema)
        {
            _context.Update(sistema);
            await _context.SaveChangesAsync();

            return sistema;
        }
    }
}
