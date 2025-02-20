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
        private readonly IJuegoQuery _juegoQuery;
        private readonly IJuegoCommand _juegoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<JuegoService> _logger;

        public JuegoService(IJuegoQuery juegoQuery, IJuegoCommand juegoCommand, IMapper mapper, ILogger<JuegoService> logger)
        {
            _juegoQuery = juegoQuery;
            _juegoCommand = juegoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse juegoResponse = new JuegoResponse();
            try
            {
                var juego = await _juegoQuery.GetById(id);

                if (juego == null)
                {
                    response.statusCode = 404;
                    response.message = "El juego seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _juegoCommand.Delete(juego);
                juegoResponse = _mapper.Map<JuegoResponse>(juego);

                _logger.LogInformation("Se eliminó el juego: " + id + ", " + juego.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Juego eliminado exitosamente";
            response.response = juegoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Juego> lista = await _juegoQuery.GetAll();
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
                Juego juego = await _juegoQuery.GetById(IdJuego);

                if (juego == null)
                {
                    response.statusCode = 404;
                    response.message = "El juego seleccionado no existe";
                    response.response = null;
                    return response;
                }

                JuegoResponse JuegoResponse = _mapper.Map<JuegoResponse>(juego);

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

        public async Task<ResponseModel> GetByUsuario(int? IdUsuario)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Juego> lista = await _juegoQuery.GetByUsuario(IdUsuario);
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


        public async Task<ResponseModel> Insert(JuegoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse juegoResponse = new JuegoResponse();
            try
            {
                Juego juego = _mapper.Map<Juego>(entity);
                juego = await _juegoCommand.Insert(juego);
                juegoResponse = _mapper.Map<JuegoResponse>(juego);

                _logger.LogInformation("Se insertó un nuevo juego: " + juego.Id + ". Nombre: " + juego.Nombre);
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
            response.response = juegoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(JuegoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoResponse juegoResponse = new JuegoResponse();
            try
            {
                var juego = await _juegoQuery.GetById(entity.Id);

                if (juego == null)
                {
                    response.statusCode = 404;
                    response.message = "El juego seleccionado no existe";
                    response.response = null;
                    return response;
                }
                                
                juego = _mapper.Map<JuegoRequest, Juego>(entity, juego);

                await _juegoCommand.Update(juego);
                juegoResponse = _mapper.Map<JuegoResponse>(juego);

                _logger.LogInformation("Se actualizó el juego: " + juego.Id + ". Nombre anterior: " + juego.Nombre + ". Nombre actual: " + entity.Nombre);
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
            response.response = juegoResponse;
            return response;
        }
    }
}
