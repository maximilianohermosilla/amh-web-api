using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.GestorExpedientes.IQueries
{
    public interface ISituacionRevistaQuery
    {
        Task<List<SituacionRevista>> GetAll();
        Task<SituacionRevista> GetById(int? id);
    }
}
