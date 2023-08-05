using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;

namespace Application.Services.General
{
    public class PaisService: IPaisService
    {
        private readonly IPaisQuery _paisQuery;
        private readonly IPaisCommand _paisCommand;

        public PaisService(IPaisQuery paisQuery, IPaisCommand paisCommand)
        {
            _paisQuery = paisQuery;
            _paisCommand = paisCommand;
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

        public Task<ResponseModel> Insert(PaisRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(PaisRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
