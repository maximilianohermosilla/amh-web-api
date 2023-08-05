using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.General.IQueries
{
    public interface ICiudadQuery
    {
        Task<List<Ciudad>> GetAll();   
        Task<Ciudad> GetById(int? id);
        Task<List<Ciudad>> GetAllByCountry(int? idPais);

    }
}
