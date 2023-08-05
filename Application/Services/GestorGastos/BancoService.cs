using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class BancoService: IBancoService
    {
        private readonly IBancoQuery _bancoQuery;
        private readonly IBancoCommand _bancoCommand;

        public BancoService(IBancoQuery bancoQuery, IBancoCommand bancoCommand)
        {
            _bancoQuery = bancoQuery;
            _bancoCommand = bancoCommand;
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

        public Task<ResponseModel> Insert(BancoRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(BancoRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
