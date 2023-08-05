using amh_web_api.DTO;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;

namespace Application.Services.MayiBeerCollection
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaQuery _marcaQuery;
        private readonly IMarcaCommand _marcaCommand;

        public MarcaService(IMarcaQuery marcaQuery, IMarcaCommand marcaCommand)
        {
            _marcaQuery = marcaQuery;
            _marcaCommand = marcaCommand;
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

        public Task<ResponseModel> Insert(MarcaDTO mercaderia)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(MarcaDTO mercaderia, int id)
        {
            throw new NotImplementedException();
        }
    }
}
