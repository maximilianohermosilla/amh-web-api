using Application.Interfaces.GestorGastos.ICommands;
using Domain.Models.GestorGastos;

namespace AccessData.Commands.GestorGastos
{
    public class RegistroAhorroCommand : IRegistroAhorroCommand
    {
        private AmhWebDbContext _context;

        public RegistroAhorroCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(RegistroAhorro entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<RegistroAhorro> entities)
        {
            _context.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<RegistroAhorro> Insert(RegistroAhorro entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<RegistroAhorro>> InsertMany(List<RegistroAhorro> entities)
        {
            _context.AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async Task<RegistroAhorro> Update(RegistroAhorro entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<RegistroAhorro>> UpdateMany(List<RegistroAhorro> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }
    }
}
