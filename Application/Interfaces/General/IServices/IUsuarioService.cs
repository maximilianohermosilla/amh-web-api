using amh_web_api.DTO;
using Application.DTO.General;
using Domain.Models.GestorExpedientes;

namespace Application.Interfaces.General.IServices
{
    public interface IUsuarioService
    {
        Task<ResponseModel> GetAll();
        Task<ResponseModel> GetById(int? id);
        Task<ResponseModel> GetByCredentials(UsuarioLoginDTO userLogin, string secretKey);
        Task<ResponseModel> Insert(UsuarioRequest entity);
        Task<ResponseModel> Update(UsuarioRequest entity);
        Task<ResponseModel> UpdatePassword(UsuarioLoginDTO entity);
        Task<ResponseModel> Delete(int id);
    }
}
