using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;

namespace Application.Services.General
{
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaQuery _sistemaQuery;
        private readonly ISistemaCommand _sistemaCommand;

        public SistemaService(ISistemaQuery sistemaQuery, ISistemaCommand sistemaCommand)
        {
            _sistemaQuery = sistemaQuery;
            _sistemaCommand = sistemaCommand;
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

        public Task<ResponseModel> Insert(SistemaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(SistemaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
