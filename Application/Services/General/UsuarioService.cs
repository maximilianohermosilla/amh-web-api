using amh_web_api.DTO;
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
