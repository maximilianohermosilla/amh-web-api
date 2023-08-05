using Application.Interfaces.GestorExpedientes.ICommands;
using Domain.Models.GestorExpedientes;

namespace AccessData.Commands.GestorExpedientes
{
    public class ExpedienteCommand : IExpedienteCommand
    {
        private AmhWebDbContext _context;

        public ExpedienteCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Expediente entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Expediente> Insert(Expediente entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Expediente> Update(Expediente entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
