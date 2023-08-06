using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorExpedientes;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorExpedientes
{
    public class ExpedienteService : IExpedienteService
    {
        private readonly IExpedienteQuery _expedienteQuery;
        private readonly IExpedienteCommand _expedienteCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<ExpedienteService> _logger;

        public ExpedienteService(IExpedienteQuery expedienteQuery, IExpedienteCommand expedienteCommand, IMapper mapper, ILogger<ExpedienteService> logger, ICervezaQuery cervezaQuery)
        {
            _expedienteQuery = expedienteQuery;
            _expedienteCommand = expedienteCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            ExpedienteResponse expedienteResponse = new ExpedienteResponse();
            try
            {
                var expediente = await _expedienteQuery.GetById(id);

                if (expediente == null)
                {
                    response.statusCode = 404;
                    response.message = "El expediente seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _expedienteCommand.Delete(expediente);
                expedienteResponse = _mapper.Map<ExpedienteResponse>(expediente);

                _logger.LogInformation("Se eliminó el expediente: " + id + ", " + expediente.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Expediente eliminado exitosamente";
            response.response = expedienteResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Expediente> lista = await _expedienteQuery.GetAll();
                List<ExpedienteResponse> listaDTO = _mapper.Map<List<ExpedienteResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdExpediente)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Expediente expediente = await _expedienteQuery.GetById(IdExpediente);

                if (expediente == null)
                {
                    response.statusCode = 404;
                    response.message = "El expediente seleccionado no existe";
                    response.response = null;
                    return response;
                }

                ExpedienteResponse ExpedienteResponse = _mapper.Map<ExpedienteResponse>(expediente);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = ExpedienteResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(ExpedienteRequest entity)
        {
            ResponseModel response = new ResponseModel();
            ExpedienteResponse expedienteResponse = new ExpedienteResponse();
            try
            {
                Expediente expediente = _mapper.Map<Expediente>(entity);
                expediente = await _expedienteCommand.Insert(expediente);
                expedienteResponse = _mapper.Map<ExpedienteResponse>(expediente);

                _logger.LogInformation("Se insertó un nuevo expediente: " + expediente.Id + ". Nombre: " + expediente.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Expediente insertado exitosamente";
            response.response = expedienteResponse;
            return response;
        }


        public async Task<ResponseModel> Update(ExpedienteRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            ExpedienteResponse expedienteResponse = new ExpedienteResponse();
            try
            {
                var expediente = await _expedienteQuery.GetById(id);

                if (expediente == null)
                {
                    response.statusCode = 404;
                    response.message = "El expediente seleccionado no existe";
                    response.response = null;
                    return response;
                }

                expediente.Nombre = entity.Nombre;

                await _expedienteCommand.Update(expediente);
                expedienteResponse = _mapper.Map<ExpedienteResponse>(expediente);

                _logger.LogInformation("Se actualizó el expediente: " + expediente.Id + ". Nombre anterior: " + expediente.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Expediente actualizado exitosamente";
            response.response = expedienteResponse;
            return response;
        }
    }
}
