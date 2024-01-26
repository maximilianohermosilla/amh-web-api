using Application.Interfaces.General.ICommands;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Commands.General
{
    public class CancionCommand : ICancionCommand
    {
        private AmhWebDbContext _context;

        public CancionCommand(AmhWebDbContext context)
        {
            _context = context;
        }

        public async Task Delete(Cancion cancion)
        {
            _context.Remove(cancion);
            await _context.SaveChangesAsync();
        }

        public async Task<Cancion> Insert(Cancion cancion)
        {
            _context.Add(cancion);
            await _context.SaveChangesAsync();

            return cancion;
        }

        public async Task<Cancion> Update(Cancion cancion)
        {
            _context.Update(cancion);
            await _context.SaveChangesAsync();

            return cancion;
        }

        public async Task Reset(List<int> ids)
        {
            var context = _context.Cancion.Where(f => ids.Contains(f.Id))
                .ExecuteUpdate(f => f.SetProperty(x => x.NombreSolicitante, x => ""));
            var result = await _context.SaveChangesAsync();
        }
    }
}
