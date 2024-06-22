using amh_web_api.DTO;

namespace Application.Interfaces.General.IServices
{
    public interface IParametrosSistemaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetByIdSistema(int? id);
        Task<ResponseModel> Insert(ParametrosSistemaRequest entity);
        Task<ResponseModel> Update(ParametrosSistemaRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
