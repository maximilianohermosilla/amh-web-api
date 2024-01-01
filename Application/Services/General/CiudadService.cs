using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models;
using Domain.Models.MayiBeerCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.General
{
    public class CiudadService: ICiudadService
    {
        private readonly ICiudadQuery _ciudadQuery;
        private readonly ICervezaQuery _cervezaQuery;
        private readonly IPaisQuery _paisQuery;
        private readonly ICiudadCommand _ciudadCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CiudadService> _logger;

        public CiudadService(ICiudadQuery ciudadQuery, ICiudadCommand ciudadCommand, IMapper mapper, IPaisQuery paisQuery, ILogger<CiudadService> logger, ICervezaQuery cervezaQuery)
        {
            _ciudadQuery = ciudadQuery;
            _ciudadCommand = ciudadCommand;
            _mapper = mapper;
            _paisQuery = paisQuery;
            _logger = logger;
            _cervezaQuery = cervezaQuery;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CiudadResponse cuidadResponse = new CiudadResponse();
            try
            {
                var ciudad = await _ciudadQuery.GetById(id);

                if (ciudad == null)
                {
                    response.statusCode = 404;
                    response.message = "La ciudad seleccionada no existe";
                    response.response = null;
                    return response;
                }

                List<Cerveza> cervezas = await _cervezaQuery.GetAll(0, 0, id, 0, false);

                if (cervezas.Any())
                {
                    response.statusCode = 409;
                    response.message = "No se puede eliminar la ciudad porque posee al menos una cerveza asignada";
                    response.response = null;
                    return response;
                }

                await _ciudadCommand.Delete(ciudad);
                cuidadResponse = _mapper.Map<CiudadResponse>(ciudad);

                _logger.LogInformation("Se eliminó la ciudad: " + id + ", " + ciudad.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Ciudad eliminada exitosamente";
            response.response = cuidadResponse;
            return response;
        }

        public async Task<ResponseModel> GetAllByCountryOrCity(int? idPais, int? idCiudad)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                if (idPais != null)
                {
                    Pais pais = await _paisQuery.GetById(idPais);

                    if (pais == null)
                    {
                        response.statusCode = 404;
                        response.message = "El país seleccionado no existe";
                        response.response = null;
                        return response;
                    }
                }

                if(idCiudad != null)
                {
                    Ciudad ciudad = await _ciudadQuery.GetById(idCiudad);
                    CiudadResponse ciudadResponse = _mapper.Map<CiudadResponse>(ciudad);
                    response.message = ciudad == null ? "No se encontró la ciudad": "Consulta realizada correctamente";
                    response.statusCode = ciudad == null ? 404: 200;
                    response.response = ciudadResponse;
                    return response;
                }

                List<Ciudad> lista = await _ciudadQuery.GetAllByCountry(idPais);
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

        public async Task<ResponseModel> Insert(CiudadRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CiudadResponse cuidadResponse = new CiudadResponse();
            try
            {
                Ciudad ciudad = _mapper.Map<Ciudad>(entity);
                ciudad = await _ciudadCommand.Insert(ciudad);
                cuidadResponse = _mapper.Map<CiudadResponse>(ciudad);

                _logger.LogInformation("Se insertó una nueva ciudad: " + ciudad.Id + ". Nombre: " + ciudad.Nombre);                
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Ciudad insertada exitosamente";
            response.response = cuidadResponse;
            return response;
        }
    

        public async Task<ResponseModel> Update(CiudadRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CiudadResponse cuidadResponse = new CiudadResponse();
            try
            {
                var ciudad = await _ciudadQuery.GetById(entity.Id);
                var pais = await _paisQuery.GetById(entity.IdPais);

                if (ciudad == null || pais == null)
                {
                    response.statusCode = 404;
                    response.message = "La ciudad o el país seleccionado no existen";
                    response.response = null;
                    return response;
                }

                ciudad.Nombre = entity.Nombre;
                ciudad.IdPais = entity.IdPais;

                await _ciudadCommand.Update(ciudad);
                cuidadResponse = _mapper.Map<CiudadResponse>(ciudad);

                _logger.LogInformation("Se actualizó la ciudad: " + ciudad.Id + ". Nombre anterior: " + ciudad.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Ciudad actualizada exitosamente";
            response.response = cuidadResponse;
            return response;
        }
    }
}
