using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionQuery _suscripcionQuery;
        private readonly ISuscripcionCommand _suscripcionCommand;

        public SuscripcionService(ISuscripcionQuery suscripcionQuery, ISuscripcionCommand suscripcionCommand)
        {
            _suscripcionQuery = suscripcionQuery;
            _suscripcionCommand = suscripcionCommand;
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

        public Task<ResponseModel> Insert(SuscripcionRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(SuscripcionRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
