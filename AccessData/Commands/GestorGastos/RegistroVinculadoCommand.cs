using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class RegistroVinculadoCommand : IRegistroVinculadoCommand
    {
        private AmhWebDbContext _context;

        public RegistroVinculadoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(RegistroVinculado entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<RegistroVinculado> Insert(RegistroVinculado entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<RegistroVinculado> Update(RegistroVinculado entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
