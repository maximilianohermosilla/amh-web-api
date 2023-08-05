using amh_web_api.DTO;
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

        public Task<ResponseModel> GetByDate(string fecha)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(List<int> mercaderias, int formaEntrega)
        {
            throw new NotImplementedException();
        }
    }
}
