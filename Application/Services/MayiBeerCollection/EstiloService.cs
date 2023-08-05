using amh_web_api.DTO;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;

namespace Application.Services.MayiBeerCollection
{
    public class EstiloService : IEstiloService
    {
        private readonly IEstiloQuery _estiloQuery;
        private readonly IEstiloCommand _estiloCommand;

        public EstiloService(IEstiloQuery estiloQuery, IEstiloCommand estiloCommand)
        {
            _estiloQuery = estiloQuery;
            _estiloCommand = estiloCommand;
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

        public Task<ResponseModel> Insert(EstiloDTO mercaderia)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(EstiloDTO mercaderia, int id)
        {
            throw new NotImplementedException();
        }
    }
}
