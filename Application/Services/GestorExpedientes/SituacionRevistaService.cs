using amh_web_api.DTO;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Domain.Models.GestorExpedientes;

namespace Application.Services.GestorExpedientes
{
    public class SituacionRevistaService : ISituacionRevistaService
    {
        private readonly ISituacionRevistaQuery _situacionRevistaQuery;
        private readonly ISituacionRevistaCommand _situacionRevistaCommand;

        public SituacionRevistaService(ISituacionRevistaQuery situacionRevistaQuery, ISituacionRevistaCommand situacionRevistaCommand)
        {
            _situacionRevistaQuery = situacionRevistaQuery;
            _situacionRevistaCommand = situacionRevistaCommand;
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

        public Task<ResponseModel> Insert(SituacionRevista entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(SituacionRevista entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
