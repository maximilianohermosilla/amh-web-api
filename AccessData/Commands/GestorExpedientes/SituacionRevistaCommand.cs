using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class SituacionRevistaCommand : ISituacionRevistaCommand
    {
        private AmhWebDbContext _context;

        public SituacionRevistaCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(SituacionRevista entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<SituacionRevista> Insert(SituacionRevista entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<SituacionRevista> Update(SituacionRevista entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
