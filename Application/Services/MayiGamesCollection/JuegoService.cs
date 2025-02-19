using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;
using Application.Interfaces.MayiGamesCollection.ICommands;
using Application.Interfaces.MayiGamesCollection.IQueries;
using Application.Interfaces.MayiGamesCollection.IServices;
using AutoMapper;
using Domain.Models.MayiGamesCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorExpedientes
{
    public class JuegoService: IJuegoService
    {
        private readonly IJuegoQuery _actoQuery;
        private readonly IJuegoCommand _actoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<JuegoService> _logger;

        public JuegoService(IJuegoQuery actoQuery, IJuegoCommand actoCommand, IMapper mapper, ILogger<JuegoService> logger)
        {
            _actoQuery = actoQuery;
            _actoCommand = actoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse actoResponse = new JuegoResponse();
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
                actoResponse = _mapper.Map<JuegoResponse>(acto);

                _logger.LogInformation("Se eliminó el acto: " + id + ", " + acto.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Juego eliminado exitosamente";
            response.response = actoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Juego> lista = await _actoQuery.GetAll();
                List<JuegoResponse> listaDTO = _mapper.Map<List<JuegoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdJuego)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Juego acto = await _actoQuery.GetById(IdJuego);

                if (acto == null)
                {
                    response.statusCode = 404;
                    response.message = "El acto seleccionado no existe";
                    response.response = null;
                    return response;
                }

                JuegoResponse JuegoResponse = _mapper.Map<JuegoResponse>(acto);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = JuegoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(JuegoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse actoResponse = new JuegoResponse();
            try
            {
                Juego acto = _mapper.Map<Juego>(entity);
                acto = await _actoCommand.Insert(acto);
                actoResponse = _mapper.Map<JuegoResponse>(acto);

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
            response.message = "Juego insertado exitosamente";
            response.response = actoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(JuegoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse actoResponse = new JuegoResponse();
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
                                
                acto = _mapper.Map<JuegoRequest, Juego>(entity, acto);

                await _actoCommand.Update(acto);
                actoResponse = _mapper.Map<JuegoResponse>(acto);

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
            response.message = "Juego actualizado exitosamente";
            response.response = actoResponse;
            return response;
        }
    }
}
