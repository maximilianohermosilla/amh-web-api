using amh_web_api.DTO;

namespace Application.Interfaces.GestorGastos.IServices
{
    public interface ICategoriaGastoService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
    }
}
