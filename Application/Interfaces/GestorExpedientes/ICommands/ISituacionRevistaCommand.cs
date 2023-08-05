using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.ICommands
{
    public interface ISituacionRevistaCommand
    {
        Task<SituacionRevista> Insert(SituacionRevista entity);
        Task<SituacionRevista> Update(SituacionRevista entity);
        Task Delete(SituacionRevista entity);
    }
}
