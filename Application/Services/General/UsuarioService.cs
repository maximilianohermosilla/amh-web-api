using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;

namespace Application.Services.General
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IUsuarioCommand _usuarioCommand;

        public UsuarioService(IUsuarioQuery usuarioQuery, IUsuarioCommand usuarioCommand)
        {
            _usuarioQuery = usuarioQuery;
            _usuarioCommand = usuarioCommand;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetByCredentials(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(UsuarioRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(UsuarioRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
