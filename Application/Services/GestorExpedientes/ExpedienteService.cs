using amh_web_api.DTO;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Domain.Models.GestorExpedientes;

namespace Application.Services.GestorExpedientes
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly IExpedienteQuery _expedienteQuery;
        private readonly IExpedienteCommand _expedienteCommand;

        public ExpedienteService(IExpedienteQuery expedienteQuery, IExpedienteCommand expedienteCommand)
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

        public Task<ResponseModel> Insert(Expediente entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(Expediente entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
