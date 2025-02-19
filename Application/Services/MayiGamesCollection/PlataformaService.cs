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
    public class PlataformaService : IPlataformaService
    {
        private readonly IPlataformaQuery _caratulaQuery;
        private readonly IPlataformaCommand _caratulaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<PlataformaService> _logger;

        public PlataformaService(IPlataformaQuery caratulaQuery, IPlataformaCommand caratulaCommand, IMapper mapper, ILogger<PlataformaService> logger, ICervezaQuery cervezaQuery)
        {
            _caratulaQuery = caratulaQuery;
            _caratulaCommand = caratulaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            PlataformaResponse caratulaResponse = new PlataformaResponse();
            try
            {
                var caratula = await _caratulaQuery.GetById(id);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _caratulaCommand.Delete(caratula);
                caratulaResponse = _mapper.Map<PlataformaResponse>(caratula);

                _logger.LogInformation("Se eliminó la caratula: " + id + ", " + caratula.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Plataforma eliminada exitosamente";
            response.response = caratulaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Plataforma> lista = await _caratulaQuery.GetAll();
                List<PlataformaResponse> listaDTO = _mapper.Map<List<PlataformaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdPlataforma)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Plataforma caratula = await _caratulaQuery.GetById(IdPlataforma);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                PlataformaResponse PlataformaResponse = _mapper.Map<PlataformaResponse>(caratula);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = PlataformaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(PlataformaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            PlataformaResponse caratulaResponse = new PlataformaResponse();
            try
            {
                Plataforma caratula = _mapper.Map<Plataforma>(entity);
                caratula = await _caratulaCommand.Insert(caratula);
                caratulaResponse = _mapper.Map<PlataformaResponse>(caratula);

                _logger.LogInformation("Se insertó una nueva caratula: " + caratula.Id + ". Nombre: " + caratula.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Plataforma insertada exitosamente";
            response.response = caratulaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(PlataformaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            PlataformaResponse caratulaResponse = new PlataformaResponse();
            try
            {
                var caratula = await _caratulaQuery.GetById(entity.Id);

                if (caratula == null)
                {
                    response.statusCode = 404;
                    response.message = "La caratula seleccionada no existe";
                    response.response = null;
                    return response;
                }

                caratula = _mapper.Map<PlataformaRequest, Plataforma>(entity, caratula);

                await _caratulaCommand.Update(caratula);
                caratulaResponse = _mapper.Map<PlataformaResponse>(caratula);

                _logger.LogInformation("Se actualizó la caratula: " + caratula.Id + ". Nombre anterior: " + caratula.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Plataforma actualizada exitosamente";
            response.response = caratulaResponse;
            return response;
        }
    }
}