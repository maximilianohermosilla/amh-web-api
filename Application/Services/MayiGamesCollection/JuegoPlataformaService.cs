using amh_web_api.DTO;
using Application.DTO.MayiGamesCollection;
using Application.Interfaces.MayiGamesCollection.ICommands;
using Application.Interfaces.MayiGamesCollection.IQueries;
using Application.Interfaces.MayiGamesCollection.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.MayiGamesCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.MayiGamesCollection
{
    public class JuegoPlataformaService : IJuegoPlataformaService
    {
        private readonly IJuegoPlataformaQuery _juegoPlataformaQuery;
        private readonly IJuegoPlataformaCommand _juegoPlataformaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<JuegoPlataformaService> _logger;

        public JuegoPlataformaService(IJuegoPlataformaQuery juegoPlataformaQuery, IJuegoPlataformaCommand juegoPlataformaCommand, IMapper mapper, ILogger<JuegoPlataformaService> logger, ICervezaQuery cervezaQuery)
        {
            _juegoPlataformaQuery = juegoPlataformaQuery;
            _juegoPlataformaCommand = juegoPlataformaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            JuegoPlataformaResponse juegoPlataformaResponse = new JuegoPlataformaResponse();
            try
            {
                var juegoPlataforma = await _juegoPlataformaQuery.GetById(id);

                if (juegoPlataforma == null)
                {
                    response.statusCode = 404;
                    response.message = "La juegoPlataforma seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _juegoPlataformaCommand.Delete(juegoPlataforma);
                juegoPlataformaResponse = _mapper.Map<JuegoPlataformaResponse>(juegoPlataforma);

                _logger.LogInformation("Se eliminó la juegoPlataforma: " + id);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Juego Plataforma eliminada exitosamente";
            response.response = juegoPlataformaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<JuegoPlataforma> lista = await _juegoPlataformaQuery.GetAll();
                List<JuegoPlataformaResponse> listaDTO = _mapper.Map<List<JuegoPlataformaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdJuegoPlataforma)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                JuegoPlataforma juegoPlataforma = await _juegoPlataformaQuery.GetById(IdJuegoPlataforma);

                if (juegoPlataforma == null)
                {
                    response.statusCode = 404;
                    response.message = "La juegoPlataforma seleccionada no existe";
                    response.response = null;
                    return response;
                }

                JuegoPlataformaResponse JuegoPlataformaResponse = _mapper.Map<JuegoPlataformaResponse>(juegoPlataforma);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = JuegoPlataformaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(JuegoPlataformaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoPlataformaResponse juegoPlataformaResponse = new JuegoPlataformaResponse();
            try
            {
                JuegoPlataforma juegoPlataforma = _mapper.Map<JuegoPlataforma>(entity);
                juegoPlataforma = await _juegoPlataformaCommand.Insert(juegoPlataforma);
                juegoPlataformaResponse = _mapper.Map<JuegoPlataformaResponse>(juegoPlataforma);

                _logger.LogInformation("Se insertó una nueva juegoPlataforma: " + juegoPlataforma.Id);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Juego Plataforma insertada exitosamente";
            response.response = juegoPlataformaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(JuegoPlataformaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            JuegoPlataformaResponse juegoPlataformaResponse = new JuegoPlataformaResponse();
            try
            {
                var juegoPlataforma = await _juegoPlataformaQuery.GetById(entity.Id);

                if (juegoPlataforma == null)
                {
                    response.statusCode = 404;
                    response.message = "La juegoPlataforma seleccionada no existe";
                    response.response = null;
                    return response;
                }

                juegoPlataforma = _mapper.Map<JuegoPlataformaRequest, JuegoPlataforma>(entity, juegoPlataforma);

                await _juegoPlataformaCommand.Update(juegoPlataforma);
                juegoPlataformaResponse = _mapper.Map<JuegoPlataformaResponse>(juegoPlataforma);

                _logger.LogInformation("Se actualizó la juegoPlataforma: " + juegoPlataforma.Id);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Juego Plataforma actualizada exitosamente";
            response.response = juegoPlataformaResponse;
            return response;
        }
    }
}