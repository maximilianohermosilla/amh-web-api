using amh_web_api.DTO;
using Application.DTO.General;

namespace Application.Interfaces.General.IServices
{
    public interface ICiudadService
    {
        Task<ResponseModel> GetAllByCountryOrCity(int? idPais, int? idCiudad);
        Task<ResponseModel> Insert(CiudadRequest entity);
        Task<ResponseModel> Update(CiudadRequest entity);
        Task<ResponseModel> Delete(int id);
    }
}
