using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class PaisCommand : IPaisCommand
    {
        private AmhWebDbContext _context;

        public PaisCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Pais pais)
        {
            _context.Remove(pais);
            await _context.SaveChangesAsync();
        }

        public async Task<Pais> Insert(Pais pais)
        {
            _context.Add(pais);
            await _context.SaveChangesAsync();

            return pais;
        }

        public async Task<Pais> Update(Pais pais)
        {
            _context.Update(pais);
            await _context.SaveChangesAsync();

            return pais;
        }
    }
}
