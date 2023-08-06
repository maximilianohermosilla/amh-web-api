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
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroQuery _registroQuery;
        private readonly IRegistroCommand _registroCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroService> _logger;

        public RegistroService(IRegistroQuery registroQuery, IRegistroCommand registroCommand, IMapper mapper, ILogger<RegistroService> logger, ICervezaQuery cervezaQuery)
        {
            _registroQuery = registroQuery;
            _registroCommand = registroCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroResponse registroResponse = new RegistroResponse();
            try
            {
                var registro = await _registroQuery.GetById(id);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _registroCommand.Delete(registro);
                registroResponse = _mapper.Map<RegistroResponse>(registro);

                _logger.LogInformation("Se eliminó el registro: " + id + ", " + registro.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Registro eliminado exitosamente";
            response.response = registroResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Registro> lista = await _registroQuery.GetAll();
                List<RegistroResponse> listaDTO = _mapper.Map<List<RegistroResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdRegistro)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Registro registro = await _registroQuery.GetById(IdRegistro);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                RegistroResponse RegistroResponse = _mapper.Map<RegistroResponse>(registro);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = RegistroResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(RegistroRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroResponse registroResponse = new RegistroResponse();
            try
            {
                Registro registro = _mapper.Map<Registro>(entity);
                registro = await _registroCommand.Insert(registro);
                registroResponse = _mapper.Map<RegistroResponse>(registro);

                _logger.LogInformation("Se insertó un nuevo registro: " + registro.Id + ". Descripcion: " + registro.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Registro insertado exitosamente";
            response.response = registroResponse;
            return response;
        }


        public async Task<ResponseModel> Update(RegistroRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroResponse registroResponse = new RegistroResponse();
            try
            {
                var registro = await _registroQuery.GetById(id);

                if (registro == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro seleccionado no existe";
                    response.response = null;
                    return response;
                }

                registro.Descripcion = entity.Descripcion;

                await _registroCommand.Update(registro);
                registroResponse = _mapper.Map<RegistroResponse>(registro);

                _logger.LogInformation("Se actualizó el registro: " + registro.Id + ". Descripcion anterior: " + registro.Descripcion + ". Descripcion actual: " + entity.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Registro actualizado exitosamente";
            response.response = registroResponse;
            return response;
        }
    }
}