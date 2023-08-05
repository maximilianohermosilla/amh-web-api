using amh_web_api.DTO;

namespace Application.Interfaces.General.IServices
{
    public interface ICiudadService
    {
        Task<ResponseModel> GetByDate(string fecha);
        Task<ResponseModel> GetById(Guid? id);
        Task<ResponseModel> Insert(List<int> mercaderias, int formaEntrega);
    }
}
