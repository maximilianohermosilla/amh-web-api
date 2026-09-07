using Application.Interfaces.General.ICommands;
using Domain.Models;

namespace AccessData.Commands.General
{
    public class ParametroConfiguracionCommand : IParametroConfiguracionCommand
    {
        private readonly AmhWebDbContext _context;

        public ParametroConfiguracionCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task<ParametroConfiguracion> Insert(ParametroConfiguracion entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ParametroConfiguracion> Update(ParametroConfiguracion entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
