using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class IngresoCommand : IIngresoCommand
    {
        private AmhWebDbContext _context;

        public IngresoCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Ingreso entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Ingreso> Insert(Ingreso entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Ingreso> Update(Ingreso entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
