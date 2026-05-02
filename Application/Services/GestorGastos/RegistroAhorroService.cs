using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Application.Services.GestorGastos
{
    public class RegistroAhorroService : IRegistroAhorroService
    {
        private readonly IRegistroAhorroQuery _registroAhorroQuery;
        private readonly IRegistroAhorroCommand _registroAhorroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroAhorroService> _logger;

        public RegistroAhorroService(IRegistroAhorroQuery registroAhorroQuery, IRegistroAhorroCommand registroAhorroCommand, IMapper mapper, ILogger<RegistroAhorroService> logger)
        {
            _registroAhorroQuery = registroAhorroQuery;
            _registroAhorroCommand = registroAhorroCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroAhorroResponse registroResponse = new RegistroAhorroResponse();
            try
            {
                var registro = await _registroAhorroQuery.GetById(id);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro de ahorro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _registroAhorroCommand.Delete(registro);
                registroResponse = _mapper.Map<RegistroAhorroResponse>(registro);

                _logger.LogInformation("Se eliminó el registro de ahorro: " + id + ", " + registro.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Registro de ahorro eliminado exitosamente";
            response.response = registroResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll(int idUsuario, string? periodo, string? descripcion)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<RegistroAhorro> lista = await _registroAhorroQuery.GetAll(idUsuario, periodo, descripcion);
                List<RegistroAhorroResponse> listaDTO = _mapper.Map<List<RegistroAhorroResponse>>(lista);

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

        public async Task<ResponseModel> GetById(int? id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                RegistroAhorro registro = await _registroAhorroQuery.GetById(id);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro de ahorro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                RegistroAhorroResponse registroResponse = _mapper.Map<RegistroAhorroResponse>(registro);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = registroResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(RegistroAhorroRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroAhorroResponse registroResponse = new RegistroAhorroResponse();
            try
            {
                RegistroAhorro registro = _mapper.Map<RegistroAhorro>(entity);
                registro = await _registroAhorroCommand.Insert(registro);
                registroResponse = _mapper.Map<RegistroAhorroResponse>(registro);

                _logger.LogInformation("Se insertó un nuevo registro de ahorro: " + registro.Id + ". Descripcion: " + registro.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Registro de ahorro insertado exitosamente";
            response.response = registroResponse;
            return response;
        }

        public async Task<ResponseModel> Update(RegistroAhorroRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroAhorroResponse registroResponse = new RegistroAhorroResponse();
            try
            {
                var registro = await _registroAhorroQuery.GetById(entity.Id);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro de ahorro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                registro = _mapper.Map<RegistroAhorroRequest, RegistroAhorro>(entity, registro);

                await _registroAhorroCommand.Update(registro);
                registroResponse = _mapper.Map<RegistroAhorroResponse>(registro);

                _logger.LogInformation("Se actualizó el registro de ahorro: " + registro.Id + ". Datos anteriores: " + JsonSerializer.Serialize(registroResponse) + ". Datos actualizados: " + JsonSerializer.Serialize(entity));                
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Registro de ahorro actualizado exitosamente";
            response.response = registroResponse;
            return response;
        }
    }
}
