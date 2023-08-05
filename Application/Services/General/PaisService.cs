using amh_web_api.DTO;
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
