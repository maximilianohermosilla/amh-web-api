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
    public class UsuarioSistemaService : IUsuarioSistemaService
    {
        private readonly IUsuarioSistemaQuery _usuarioSistemaQuery;
        private readonly IUsuarioSistemaCommand _usuarioSistemaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<UsuarioSistemaService> _logger;

        public UsuarioSistemaService(IUsuarioSistemaQuery usuarioSistemaQuery, IUsuarioSistemaCommand usuarioSistemaCommand, IMapper mapper, ILogger<UsuarioSistemaService> logger)
        {
            _usuarioSistemaQuery = usuarioSistemaQuery;
            _usuarioSistemaCommand = usuarioSistemaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            UsuarioSistemaResponse usuarioSistemaResponse = new UsuarioSistemaResponse();
            try
            {
                var usuarioSistema = await _usuarioSistemaQuery.GetById(id);

                if (usuarioSistema == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro ingresado no existe";
                    response.response = null;
                    return response;
                }

                await _usuarioSistemaCommand.Delete(usuarioSistema);
                usuarioSistemaResponse = _mapper.Map<UsuarioSistemaResponse>(usuarioSistema);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
            }

            response.statusCode = 200;
            response.message = "Relación Usuario/Sistema eliminada exitosamente";
            response.response = usuarioSistemaResponse;
            _logger.LogInformation("Se eliminó la relación Usuario: " + usuarioSistemaResponse.IdUsuario + ", Sistema: " + usuarioSistemaResponse.IdSistema);
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<UsuarioSistema> lista = await _usuarioSistemaQuery.GetAll();
                List<UsuarioSistemaResponse> listaDTO = _mapper.Map<List<UsuarioSistemaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int IdUsuarioSistema)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                UsuarioSistema usuarioSistema = await _usuarioSistemaQuery.GetById(IdUsuarioSistema);

                if (usuarioSistema == null)
                {
                    response.statusCode = 404;
                    response.message = "La relación de usuario y sistema no existe";
                    response.response = null;
                    return response;
                }

                UsuarioSistemaResponse usuarioSistemaResponse = _mapper.Map<UsuarioSistemaResponse>(usuarioSistema);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioSistemaResponse;
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

        public async Task<ResponseModel> Insert(UsuarioSistemaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            UsuarioSistemaResponse usuarioSistemaResponse = new UsuarioSistemaResponse();
            try
            {
                UsuarioSistema usuarioSistema = _mapper.Map<UsuarioSistema>(entity);
                usuarioSistema = await _usuarioSistemaCommand.Insert(usuarioSistema);
                usuarioSistemaResponse = _mapper.Map<UsuarioSistemaResponse>(usuarioSistema);                
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                _logger.LogError($"{ex.Message}");
                return response;
            }

            response.statusCode = 201;
            response.message = "Relación Usuario/Sistema insertada exitosamente";
            response.response = usuarioSistemaResponse;
            _logger.LogInformation("Se insertó una nueva relación Usuario: " + usuarioSistemaResponse.IdUsuario + ". Sistema: " + usuarioSistemaResponse.IdSistema);
            return response;
        }

        public async Task<ResponseModel> GetByUsuarioSistema(int? idUsuario, int? idSistema)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                UsuarioSistema usuarioSistema = await _usuarioSistemaQuery.GetByUsuarioSistema(idUsuario, idSistema);

                if (usuarioSistema == null)
                {
                    response.statusCode = 404;
                    response.message = "La relación de usuario y sistema no existe";
                    response.response = null;
                    return response;
                }

                UsuarioSistemaResponse usuarioSistemaResponse = _mapper.Map<UsuarioSistemaResponse>(usuarioSistema);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = usuarioSistemaResponse;
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
