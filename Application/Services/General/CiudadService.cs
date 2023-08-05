using amh_web_api.DTO;
using Application.DTO.General;
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

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAllByCountry(int? idPais)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(CiudadRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(CiudadRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
