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
    public class SistemaService : ISistemaService
    {
        private readonly ISistemaQuery _sistemaQuery;
        private readonly ISistemaCommand _sistemaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<SistemaService> _logger;

        public SistemaService(ISistemaQuery sistemaQuery, ISistemaCommand sistemaCommand, IMapper mapper, ILogger<SistemaService> logger)
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
                List<Sistema> lista = await _sistemaQuery.GetAll();
                List<SistemaResponse> listaDTO = _mapper.Map<List<SistemaResponse>>(lista);

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

        public async Task<ResponseModel> GetById(int? id)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Sistema sistema = await _sistemaQuery.GetById(id);

                if (sistema == null)
                {
                    response.statusCode = 404;
                    response.message = "El sistema seleccionado no existe";
                    response.response = null;
                    return response;
                }

                SistemaResponse sistemaResponse = _mapper.Map<SistemaResponse>(sistema);

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

        public Task<ResponseModel> Insert(SistemaRequest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Update(SistemaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            SistemaResponse sistemaResponse = new SistemaResponse();
            try
            {
                var sistema = await _sistemaQuery.GetById(entity.Id);

                if (sistema == null)
                {
                    response.statusCode = 404;
                    response.message = "El sistema seleccionado no existe";
                    response.response = null;
                    return response;
                }

                sistema.Descripcion = entity.Descripcion;

                await _sistemaCommand.Update(sistema);
                sistemaResponse = _mapper.Map<SistemaResponse>(sistema);

                _logger.LogInformation("Se actualizó el sistema: " + sistema.Id + ". Nombre anterior: " + sistema.Descripcion + ". Nombre actual: " + entity.Descripcion);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Sistema actualizado exitosamente";
            response.response = sistemaResponse;
            return response;
        }
    }
}
