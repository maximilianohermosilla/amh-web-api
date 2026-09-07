using Domain.Models;

namespace Application.Interfaces.General.IQueries
{
    public interface IParametroConfiguracionQuery
    {
        Task<ParametroConfiguracion> GetById(int id);
        Task<List<ParametroConfiguracion>> GetAllByIdSistema(int idSistema);
        Task<ParametroConfiguracion> GetByNombre(string nombre, int idSistema);
    }
}
