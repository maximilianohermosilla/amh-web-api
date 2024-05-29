using amh_web_api.DTO;
using Application.DTO.GestorExpedientes;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorExpedientes.ICommands;
using Application.Interfaces.GestorExpedientes.IQueries;
using Application.Interfaces.GestorExpedientes.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorExpedientes;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorExpedientes
{
    public class ActoService: IActoService
    {
        private readonly IActoQuery _actoQuery;
        private readonly IActoCommand _actoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<ActoService> _logger;

        public ActoService(IActoQuery actoQuery, IActoCommand actoCommand, IMapper mapper, ILogger<ActoService> logger, ICervezaQuery cervezaQuery)
        {
            _actoQuery = actoQuery;
            _actoCommand = actoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            ActoResponse actoResponse = new ActoResponse();
            try
            {
                var acto = await _actoQuery.GetById(id);

                if (acto == null)
                {
                    response.statusCode = 404;
                    response.message = "El acto seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _actoCommand.Delete(acto);
                actoResponse = _mapper.Map<ActoResponse>(acto);

                _logger.LogInformation("Se eliminó el acto: " + id + ", " + acto.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Acto eliminado exitosamente";
            response.response = actoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Acto> lista = await _actoQuery.GetAll();
                List<ActoResponse> listaDTO = _mapper.Map<List<ActoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdActo)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Acto acto = await _actoQuery.GetById(IdActo);

                if (acto == null)
                {
                    response.statusCode = 404;
                    response.message = "El acto seleccionado no existe";
                    response.response = null;
                    return response;
                }

                ActoResponse ActoResponse = _mapper.Map<ActoResponse>(acto);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = ActoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(ActoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            ActoResponse actoResponse = new ActoResponse();
            try
            {
                Acto acto = _mapper.Map<Acto>(entity);
                acto = await _actoCommand.Insert(acto);
                actoResponse = _mapper.Map<ActoResponse>(acto);

                _logger.LogInformation("Se insertó un nuevo acto: " + acto.Id + ". Nombre: " + acto.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Acto insertado exitosamente";
            response.response = actoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(ActoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            ActoResponse actoResponse = new ActoResponse();
            try
            {
                var acto = await _actoQuery.GetById(entity.Id);

                if (acto == null)
                {
                    response.statusCode = 404;
                    response.message = "El acto seleccionado no existe";
                    response.response = null;
                    return response;
                }
                                
                acto = _mapper.Map<ActoRequest, Acto>(entity, acto);

                await _actoCommand.Update(acto);
                actoResponse = _mapper.Map<ActoResponse>(acto);

                _logger.LogInformation("Se actualizó el acto: " + acto.Id + ". Nombre anterior: " + acto.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Acto actualizado exitosamente";
            response.response = actoResponse;
            return response;
        }
    }
}
