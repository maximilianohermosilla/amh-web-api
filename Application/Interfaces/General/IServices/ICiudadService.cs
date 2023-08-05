using amh_web_api.DTO;
using Application.DTO.General;
using Domain.Models.GestorExpedientes;
using Domain.Models.MayiBeerCollection;

namespace Application.Interfaces.General.IServices
{
    public interface ICiudadService
    {
        Task<ResponseModel> GetAllByCountryOrCity(int? idPais, int? idCiudad);
        Task<ResponseModel> Insert(CiudadRequest entity);
        Task<ResponseModel> Update(CiudadRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
