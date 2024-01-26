using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface ICancionQuery
    {
        Task<List<Cancion>> GetAll();   
        Task<Cancion> GetById(int? id);
        Task<List<Cancion>> GetAllById(List<int> ids);
    }
}
