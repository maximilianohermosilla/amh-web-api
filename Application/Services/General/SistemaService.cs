using amh_web_api.DTO;
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
