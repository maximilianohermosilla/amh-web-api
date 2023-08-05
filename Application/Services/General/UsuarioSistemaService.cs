using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;

namespace Application.Services.General
{
    public class UsuarioSistemaService : IUsuarioSistemaService
    {
        private readonly IUsuarioSistemaQuery _usuarioSistemaQuery;
        private readonly IUsuarioSistemaCommand _usuarioSistemaCommand;

        public UsuarioSistemaService(IUsuarioSistemaQuery usuarioSistemaQuery, IUsuarioSistemaCommand usuarioSistemaCommand)
        {
            _usuarioSistemaQuery = usuarioSistemaQuery;
            _usuarioSistemaCommand = usuarioSistemaCommand;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetByUsuarioSistema(int? idUsuario, int? idSistema)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(UsuarioSistemaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(UsuarioSistemaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
