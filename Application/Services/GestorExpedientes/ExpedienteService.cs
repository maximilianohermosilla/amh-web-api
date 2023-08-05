using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;

namespace Application.Services.GestorExpedientes
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly IExpedienteQuery _expedienteQuery;
        private readonly ISituacionRevistaCommand _expedienteCommand;

        public ExpedienteService(IExpedienteQuery expedienteQuery, ISituacionRevistaCommand expedienteCommand)
        {
            _expedienteQuery = expedienteQuery;
            _expedienteCommand = expedienteCommand;
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

        public Task<ResponseModel> Insert(ExpedienteRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(ExpedienteRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
