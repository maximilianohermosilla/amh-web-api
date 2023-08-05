using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Domain.Models.GestorGastos;

namespace Application.Services.GestorGastos
{
    public class TipoTarjetaService: ITipoTarjetaService
    {
        private readonly ITipoTarjetaQuery _tipoTarjetaQuery;
        private readonly ITipoTarjetaCommand _tipoTarjetaCommand;

        public TipoTarjetaService(ITipoTarjetaQuery tipoTarjetaQuery, ITipoTarjetaCommand tipoTarjetaCommand)
        {
            _tipoTarjetaQuery = tipoTarjetaQuery;
            _tipoTarjetaCommand = tipoTarjetaCommand;
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

        public Task<ResponseModel> Insert(TipoTarjetaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(TipoTarjetaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
