using amh_web_api.DTO;
using Application.DTO.General;

namespace Application.Interfaces.General.IServices
{
    public interface IParametroConfiguracionService
    {
        Task<ResponseModel> Insert(ParametroConfiguracionRequest entity);
        Task<ResponseModel> Update(ParametroConfiguracionRequest entity);
        Task<ResponseModel> GetAllByIdSistema(int idSistema);
        Task<ResponseModel> GetByNombre(string nombre, int idSistema);
    }
}
