using amh_web_api.DTO;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;

namespace Application.Services.General
{
    public class CiudadService: ICiudadService
    {
        private readonly ICiudadQuery _ciudadQuery;
        private readonly ICiudadCommand _ciudadCommand;

        public CiudadService(ICiudadQuery ciudadQuery, ICiudadCommand ciudadCommand)
        {
            _ciudadQuery = ciudadQuery;
            _ciudadCommand = ciudadCommand;
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
