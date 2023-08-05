using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class ActoCommand : IActoCommand
    {
        private AmhWebDbContext _context;

        public ActoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Acto entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Acto> Insert(Acto entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Acto> Update(Acto entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
