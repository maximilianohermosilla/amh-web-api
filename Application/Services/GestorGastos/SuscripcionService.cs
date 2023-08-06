using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorGastos
{
    public class SuscripcionService : ISuscripcionService
    {
        private readonly ISuscripcionQuery _suscripcionQuery;
        private readonly ISuscripcionCommand _suscripcionCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<SuscripcionService> _logger;

        public SuscripcionService(ISuscripcionQuery suscripcionQuery, ISuscripcionCommand suscripcionCommand, IMapper mapper, ILogger<SuscripcionService> logger, ICervezaQuery cervezaQuery)
        {
            _suscripcionQuery = suscripcionQuery;
            _suscripcionCommand = suscripcionCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                var suscripcion = await _suscripcionQuery.GetById(id);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _suscripcionCommand.Delete(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                _logger.LogInformation("Se eliminó la suscripcion: " + id + ", " + suscripcion.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Suscripcion eliminada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Suscripcion> lista = await _suscripcionQuery.GetAll();
                List<SuscripcionResponse> listaDTO = _mapper.Map<List<SuscripcionResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdSuscripcion)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Suscripcion suscripcion = await _suscripcionQuery.GetById(IdSuscripcion);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                SuscripcionResponse SuscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = SuscripcionResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(SuscripcionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                Suscripcion suscripcion = _mapper.Map<Suscripcion>(entity);
                suscripcion = await _suscripcionCommand.Insert(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                _logger.LogInformation("Se insertó una nueva suscripcion: " + suscripcion.Id + ". Nombre: " + suscripcion.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Suscripcion insertada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }


        public async Task<ResponseModel> Update(SuscripcionRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            SuscripcionResponse suscripcionResponse = new SuscripcionResponse();
            try
            {
                var suscripcion = await _suscripcionQuery.GetById(id);

                if (suscripcion == null)
                {
                    response.statusCode = 404;
                    response.message = "La suscripcion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                suscripcion.Nombre = entity.Nombre;

                await _suscripcionCommand.Update(suscripcion);
                suscripcionResponse = _mapper.Map<SuscripcionResponse>(suscripcion);

                _logger.LogInformation("Se actualizó la suscripcion: " + suscripcion.Id + ". Nombre anterior: " + suscripcion.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Suscripcion actualizada exitosamente";
            response.response = suscripcionResponse;
            return response;
        }
    }
}