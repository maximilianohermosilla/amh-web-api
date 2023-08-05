using Domain.Models;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.General.IQueries
{
    public interface ISistemaQuery
    {
        Task<List<Sistema>> GetAll();
        Task<Sistema> GetById(int? id);
    }
}
