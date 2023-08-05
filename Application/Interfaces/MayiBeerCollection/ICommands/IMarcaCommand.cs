using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.MayiBeerCollection.ICommands
{
    public interface IMarcaCommand
    {
        Task<Marca> Insert(Marca marca);
        Task<Marca> Update(Marca marca);
        Task Delete(Marca marca);
    }
}
