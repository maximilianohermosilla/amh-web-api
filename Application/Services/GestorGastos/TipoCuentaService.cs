using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class TipoCuentaService: ITipoCuentaService
    {
        private readonly ITipoCuentaQuery _tipoCuentaQuery;
        private readonly ITipoCuentaCommand _tipoCuentaCommand;

        public TipoCuentaService(ITipoCuentaQuery tipoCuentaQuery, ITipoCuentaCommand tipoCuentaCommand)
        {
            _tipoCuentaQuery = tipoCuentaQuery;
            _tipoCuentaCommand = tipoCuentaCommand;
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

        public Task<ResponseModel> Insert(TipoCuentaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(TipoCuentaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
