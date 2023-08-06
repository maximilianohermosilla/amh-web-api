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
    public class RegistroVinculadoService : IRegistroVinculadoService
    {
        private readonly IRegistroVinculadoQuery _registroVinculadoQuery;
        private readonly IRegistroVinculadoCommand _registroVinculadoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<RegistroVinculadoService> _logger;

        public RegistroVinculadoService(IRegistroVinculadoQuery registroVinculadoQuery, IRegistroVinculadoCommand registroVinculadoCommand, IMapper mapper, ILogger<RegistroVinculadoService> logger, ICervezaQuery cervezaQuery)
        {
            _registroVinculadoQuery = registroVinculadoQuery;
            _registroVinculadoCommand = registroVinculadoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                var registroVinculado = await _registroVinculadoQuery.GetById(id);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _registroVinculadoCommand.Delete(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                _logger.LogInformation("Se eliminó el registro vinculado: " + id + ", " + registroVinculado.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Registro vinculado eliminado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<RegistroVinculado> lista = await _registroVinculadoQuery.GetAll();
                List<RegistroVinculadoResponse> listaDTO = _mapper.Map<List<RegistroVinculadoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdRegistroVinculado)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                RegistroVinculado registroVinculado = await _registroVinculadoQuery.GetById(IdRegistroVinculado);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                RegistroVinculadoResponse RegistroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = RegistroVinculadoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(RegistroVinculadoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                RegistroVinculado registroVinculado = _mapper.Map<RegistroVinculado>(entity);
                registroVinculado = await _registroVinculadoCommand.Insert(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                _logger.LogInformation("Se insertó un nuevo registro vinculado: " + registroVinculado.Id + ". Descripcion: " + registroVinculado.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Registro vinculado insertado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(RegistroVinculadoRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            RegistroVinculadoResponse registroVinculadoResponse = new RegistroVinculadoResponse();
            try
            {
                var registroVinculado = await _registroVinculadoQuery.GetById(id);

                if (registroVinculado == null)
                {
                    response.statusCode = 404;
                    response.message = "El registro vinculado seleccionado no existe";
                    response.response = null;
                    return response;
                }

                registroVinculado.Descripcion = entity.Descripcion;

                await _registroVinculadoCommand.Update(registroVinculado);
                registroVinculadoResponse = _mapper.Map<RegistroVinculadoResponse>(registroVinculado);

                _logger.LogInformation("Se actualizó el registro vinculado: " + registroVinculado.Id + ". Descripcion anterior: " + registroVinculado.Descripcion + ". Descripcion actual: " + entity.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Registro vinculado actualizado exitosamente";
            response.response = registroVinculadoResponse;
            return response;
        }
    }
}