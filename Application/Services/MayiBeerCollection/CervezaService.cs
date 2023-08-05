using amh_web_api.DTO;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;

namespace Application.Services.MayiBeerCollection
{
    public class CervezaService: ICervezaService
    {
        private readonly ICervezaQuery _cervezaQuery;
        private readonly ICervezaCommand _cervezaCommand;

        public CervezaService(ICervezaQuery cervezaQuery, ICervezaCommand cervezaCommand)
        {
            _cervezaQuery = cervezaQuery;
            _cervezaCommand = cervezaCommand;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteComandaMercaderia(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAllByType(int tipoMercaderiaId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetByTypeNameOrder(int? tipo, string? nombre, string orden)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(CervezaDTO mercaderia)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(CervezaDTO mercaderia, int id)
        {
            throw new NotImplementedException();
        }
    }
}
