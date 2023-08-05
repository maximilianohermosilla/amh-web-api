using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.ICommands
{
    public interface IEstiloCommand
    {
        Task<Estilo> Insert(Estilo estilo);
        Task<Estilo> Update(Estilo estilo);
        Task Delete(Estilo estilo);
    }
}
