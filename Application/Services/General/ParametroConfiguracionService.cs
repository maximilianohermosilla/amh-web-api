using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.Services.General
{
    public class ParametroConfiguracionService : IParametroConfiguracionService
    {
        private readonly IParametroConfiguracionQuery _query;
        private readonly IParametroConfiguracionCommand _command;
        private readonly IMapper _mapper;
        private readonly ILogger<ParametroConfiguracionService> _logger;

        public ParametroConfiguracionService(IParametroConfiguracionQuery query, IParametroConfiguracionCommand command, IMapper mapper, ILogger<ParametroConfiguracionService> logger)
        {
            _query = query;
            _command = command;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> GetAllByIdSistema(int idSistema)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var list = await _query.GetAllByIdSistema(idSistema);
                var listDTO = _mapper.Map<List<ParametroConfiguracionResponse>>(list);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = listDTO;
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

        public async Task<ResponseModel> GetByNombre(string nombre, int idSistema)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var param = await _query.GetByNombre(nombre, idSistema);
                if (param == null)
                {
                    response.statusCode = 404;
                    response.message = "Parámetro no encontrado";
                    response.response = null;
                    return response;
                }

                var paramDTO = _mapper.Map<ParametroConfiguracionResponse>(param);
                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = paramDTO;
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

        public async Task<ResponseModel> Insert(ParametroConfiguracionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var param = _mapper.Map<ParametroConfiguracion>(entity);
                var result = await _command.Insert(param);
                
                var resultDTO = _mapper.Map<ParametroConfiguracionResponse>(result);
                response.message = "Inserción realizada correctamente";
                response.statusCode = 201;
                response.response = resultDTO;
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

        public async Task<ResponseModel> Update(ParametroConfiguracionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var currentParam = await _query.GetById(entity.Id);
                if (currentParam == null)
                {
                    response.statusCode = 404;
                    response.message = "El parámetro a actualizar no existe";
                    response.response = null;
                    return response;
                }

                currentParam.Nombre = entity.Nombre;
                currentParam.Valor = entity.Valor;
                currentParam.IdSistema = entity.IdSistema;

                var result = await _command.Update(currentParam);
                var resultDTO = _mapper.Map<ParametroConfiguracionResponse>(result);

                response.message = "Actualización realizada correctamente";
                response.statusCode = 200;
                response.response = resultDTO;
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
    }
}
