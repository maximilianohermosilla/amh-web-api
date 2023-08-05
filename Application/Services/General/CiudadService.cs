using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using AutoMapper;
using Domain.Models;

namespace Application.Services.General
{
    public class CiudadService: ICiudadService
    {
        private readonly ICiudadQuery _ciudadQuery;
        private readonly ICiudadCommand _ciudadCommand;
        private readonly IMapper _mapper;

        public CiudadService(ICiudadQuery ciudadQuery, ICiudadCommand ciudadCommand, IMapper mapper)
        {
            _ciudadQuery = ciudadQuery;
            _ciudadCommand = ciudadCommand;
            _mapper = mapper;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();            

            try
            {
                List<Ciudad> lista = await _ciudadQuery.GetAll();
                List<CiudadResponse> listaDTO = _mapper.Map<List<CiudadResponse>>(lista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
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
