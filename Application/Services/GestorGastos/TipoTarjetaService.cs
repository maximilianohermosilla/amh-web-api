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
    public class TipoTarjetaService: ITipoTarjetaService
    {
        private readonly ITipoTarjetaQuery _tipoTarjetaQuery;
        private readonly ITipoTarjetaCommand _tipoTarjetaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<TipoTarjetaService> _logger;

        public TipoTarjetaService(ITipoTarjetaQuery tipoTarjetaQuery, ITipoTarjetaCommand tipoTarjetaCommand, IMapper mapper, ILogger<TipoTarjetaService> logger, ICervezaQuery cervezaQuery)
        {
            _tipoTarjetaQuery = tipoTarjetaQuery;
            _tipoTarjetaCommand = tipoTarjetaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            TipoTarjetaResponse tipoTarjetaResponse = new TipoTarjetaResponse();
            try
            {
                var tipoTarjeta = await _tipoTarjetaQuery.GetById(id);

                if (tipoTarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de tarjeta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _tipoTarjetaCommand.Delete(tipoTarjeta);
                tipoTarjetaResponse = _mapper.Map<TipoTarjetaResponse>(tipoTarjeta);

                _logger.LogInformation("Se eliminó el tipo de tarjeta: " + id + ", " + tipoTarjeta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Tipo de tarjeta eliminado exitosamente";
            response.response = tipoTarjetaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<TipoTarjeta> lista = await _tipoTarjetaQuery.GetAll();
                List<TipoTarjetaResponse> listaDTO = _mapper.Map<List<TipoTarjetaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdTipoTarjeta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                TipoTarjeta tipoTarjeta = await _tipoTarjetaQuery.GetById(IdTipoTarjeta);

                if (tipoTarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de tarjeta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                TipoTarjetaResponse TipoTarjetaResponse = _mapper.Map<TipoTarjetaResponse>(tipoTarjeta);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = TipoTarjetaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(TipoTarjetaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            TipoTarjetaResponse tipoTarjetaResponse = new TipoTarjetaResponse();
            try
            {
                TipoTarjeta tipoTarjeta = _mapper.Map<TipoTarjeta>(entity);
                tipoTarjeta = await _tipoTarjetaCommand.Insert(tipoTarjeta);
                tipoTarjetaResponse = _mapper.Map<TipoTarjetaResponse>(tipoTarjeta);

                _logger.LogInformation("Se insertó un nuevo tipo de tarjeta: " + tipoTarjeta.Id + ". Nombre: " + tipoTarjeta.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Tipo de tarjeta insertado exitosamente";
            response.response = tipoTarjetaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(TipoTarjetaRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            TipoTarjetaResponse tipoTarjetaResponse = new TipoTarjetaResponse();
            try
            {
                var tipoTarjeta = await _tipoTarjetaQuery.GetById(id);

                if (tipoTarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "El tipo de tarjeta seleccionado no existe";
                    response.response = null;
                    return response;
                }

                tipoTarjeta.Nombre = entity.Nombre;

                await _tipoTarjetaCommand.Update(tipoTarjeta);
                tipoTarjetaResponse = _mapper.Map<TipoTarjetaResponse>(tipoTarjeta);

                _logger.LogInformation("Se actualizó el tipo de tarjeta: " + tipoTarjeta.Id + ". Nombre anterior: " + tipoTarjeta.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Tipo de tarjeta actualizado exitosamente";
            response.response = tipoTarjetaResponse;
            return response;
        }
    }
}