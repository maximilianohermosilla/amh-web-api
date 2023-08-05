using amh_web_api.DTO;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Domain.Models.GestorExpedientes;

namespace Application.Services.GestorExpedientes
{
    public class ActoService: IActoService
    {
        private readonly IActoQuery _actoQuery;
        private readonly ISituacionRevistaCommand _actoCommand;

        public ActoService(IActoQuery actoQuery, ISituacionRevistaCommand actoCommand)
        {
            _actoQuery = actoQuery;
            _actoCommand = actoCommand;
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

        public Task<ResponseModel> Insert(Acto entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(Acto entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
