using amh_web_api.DTO;
using Application.DTO.General;
using Domain.Models;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.General.IServices
{
    public interface IUsuarioSistemaService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> GetByUsuarioSistema(int? idUsuario, int? idSistema);
        Task<ResponseModel> Insert(UsuarioSistemaRequest entity);
        Task<ResponseModel> Update(UsuarioSistemaRequest entity, int id);
        Task<ResponseModel> Delete(int id);
    }
}
