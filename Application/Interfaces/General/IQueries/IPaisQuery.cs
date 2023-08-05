using Domain.Models;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.General.IQueries
{
    public interface IPaisQuery
    {
        Task<List<Pais>> GetAll();
        Task<Pais> GetById(int? id);
    }
}
