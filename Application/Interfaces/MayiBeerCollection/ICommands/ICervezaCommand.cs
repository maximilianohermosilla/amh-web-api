using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.ICommands
{
    public interface ICervezaCommand
    {
        Task<Cerveza> Insert(Cerveza cerveza);
        Task<Cerveza> Update(Cerveza cerveza);
        Task Delete(Cerveza cerveza);
    }
}
