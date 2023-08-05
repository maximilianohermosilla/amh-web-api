using amh_web_api.DTO;
using Application.DTO.General;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.General.IServices
{
    public interface ISistemaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> Insert(SistemaRequest entity);
        Task<ResponseModel> Update(SistemaRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
