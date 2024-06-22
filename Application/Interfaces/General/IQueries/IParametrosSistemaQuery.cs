using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IParametrosSistemaQuery
    {
        Task<List<ParametrosSistema>> GetAll();
        Task<ParametrosSistema> GetByIdSistema(int? idSistema);
    }
}
