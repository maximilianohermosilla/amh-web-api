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
    public class TarjetaService: ITarjetaService
    {
        private readonly ITarjetaQuery _tarjetaQuery;
        private readonly ITarjetaCommand _tarjetaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<TarjetaService> _logger;

        public TarjetaService(ITarjetaQuery tarjetaQuery, ITarjetaCommand tarjetaCommand, IMapper mapper, ILogger<TarjetaService> logger, ICervezaQuery cervezaQuery)
        {
            _tarjetaQuery = tarjetaQuery;
            _tarjetaCommand = tarjetaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            TarjetaResponse tarjetaResponse = new TarjetaResponse();
            try
            {
                var tarjeta = await _tarjetaQuery.GetById(id);

                if (tarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "La tarjeta seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _tarjetaCommand.Delete(tarjeta);
                tarjetaResponse = _mapper.Map<TarjetaResponse>(tarjeta);

                _logger.LogInformation("Se eliminó la tarjeta: " + id + ", " + tarjeta.Numero);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Tarjeta eliminada exitosamente";
            response.response = tarjetaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Tarjeta> lista = await _tarjetaQuery.GetAll(idUsuario);
                List<TarjetaResponse> listaDTO = _mapper.Map<List<TarjetaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdTarjeta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Tarjeta tarjeta = await _tarjetaQuery.GetById(IdTarjeta);

                if (tarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "La tarjeta seleccionada no existe";
                    response.response = null;
                    return response;
                }

                TarjetaResponse TarjetaResponse = _mapper.Map<TarjetaResponse>(tarjeta);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = TarjetaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(TarjetaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            TarjetaResponse tarjetaResponse = new TarjetaResponse();
            try
            {
                Tarjeta tarjeta = _mapper.Map<Tarjeta>(entity);
                tarjeta = await _tarjetaCommand.Insert(tarjeta);
                tarjetaResponse = _mapper.Map<TarjetaResponse>(tarjeta);

                _logger.LogInformation("Se insertó una nueva tarjeta: " + tarjeta.Id + ". Numero: " + tarjeta.Numero);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Tarjeta insertada exitosamente";
            response.response = tarjetaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(TarjetaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            TarjetaResponse tarjetaResponse = new TarjetaResponse();
            try
            {
                var tarjeta = await _tarjetaQuery.GetById(entity.Id);

                if (tarjeta == null)
                {
                    response.statusCode = 404;
                    response.message = "La tarjeta seleccionada no existe";
                    response.response = null;
                    return response;
                }

                tarjeta = _mapper.Map<TarjetaRequest, Tarjeta>(entity, tarjeta);

                await _tarjetaCommand.Update(tarjeta);
                tarjetaResponse = _mapper.Map<TarjetaResponse>(tarjeta);

                _logger.LogInformation("Se actualizó la tarjeta: " + tarjeta.Id + ". Numero anterior: " + tarjeta.Numero + ". Numero actual: " + entity.Numero);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Tarjeta actualizada exitosamente";
            response.response = tarjetaResponse;
            return response;
        }
    }
}