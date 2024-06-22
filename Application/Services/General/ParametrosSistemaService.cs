using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using Application.Interfaces.GestorGastos.ICommands;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.General
{
    public class ParametrosSistemaService : IParametrosSistemaService
    {
        private readonly IParametrosSistemaQuery _sistemaQuery;
        private readonly IParametrosSistemaCommand _sistemaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<ParametrosSistemaService> _logger;

        public ParametrosSistemaService(IParametrosSistemaQuery sistemaQuery, IParametrosSistemaCommand sistemaCommand, IMapper mapper, ILogger<ParametrosSistemaService> logger)
        {
            _sistemaQuery = sistemaQuery;
            _sistemaCommand = sistemaCommand;
            _mapper = mapper;
            _logger = logger;
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
                List<ParametrosSistema> lista = await _sistemaQuery.GetAll();
                List<ParametrosSistemaResponse> listaDTO = _mapper.Map<List<ParametrosSistemaResponse>>(lista);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listaDTO;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
            }

            return response;
        }

        public async Task<ResponseModel> GetByIdSistema(int? id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ParametrosSistema sistema = await _sistemaQuery.GetByIdSistema(id);

                if (sistema == null)
                {
                    response.statusCode = 404;
                    response.message = "El sistema seleccionado no existe";
                    response.response = null;
                    return response;
                }

                ParametrosSistemaResponse sistemaResponse = _mapper.Map<ParametrosSistemaResponse>(sistema);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = sistemaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(ParametrosSistemaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            ParametrosSistemaResponse parametrosSistemaResponse = new ParametrosSistemaResponse();
            try
            {
                ParametrosSistema parametros = _mapper.Map<ParametrosSistema>(entity);
                parametros = await _sistemaCommand.Insert(parametros);
                parametrosSistemaResponse = _mapper.Map<ParametrosSistemaResponse>(parametros);

                _logger.LogInformation("Se insertó un nuevo parámetro: " + parametros.Id + ". Host: " + parametros.Host + ". Port: " + parametros.Port.ToString() + ". User: " + parametros.User + ". Password: " + parametros.Password);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Parámetros insertados exitosamente";
            response.response = parametrosSistemaResponse;
            return response;
        }

        public async Task<ResponseModel> Update(ParametrosSistemaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            ParametrosSistemaResponse sistemaResponse = new ParametrosSistemaResponse();
            try
            {
                var sistema = await _sistemaQuery.GetByIdSistema(entity.Id);

                if (sistema == null)
                {
                    response.statusCode = 404;
                    response.message = "El sistema seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _sistemaCommand.Update(sistema);
                sistemaResponse = _mapper.Map<ParametrosSistemaResponse>(sistema);

                _logger.LogInformation("Se actualizaron los parametros del sistema: " + sistema.Id);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Parametros del Sistema actualizados exitosamente";
            response.response = sistemaResponse;
            return response;
        }
    }
}
