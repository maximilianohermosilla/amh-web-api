using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class TarjetaService: ITarjetaService
    {
        private readonly ITarjetaQuery _tarjetaQuery;
        private readonly ITarjetaCommand _tarjetaCommand;

        public TarjetaService(ITarjetaQuery tarjetaQuery, ITarjetaCommand tarjetaCommand)
        {
            _tarjetaQuery = tarjetaQuery;
            _tarjetaCommand = tarjetaCommand;
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

        public Task<ResponseModel> Insert(TarjetaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(TarjetaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
