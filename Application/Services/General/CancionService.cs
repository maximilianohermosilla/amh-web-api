using amh_web_api.DTO;
using Application.DTO.General;
using Application.Interfaces.General.ICommands;
using Application.Interfaces.General.IQueries;
using Application.Interfaces.General.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models;
using Domain.Models.MayiBeerCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.General
{
    public class CancionService: ICancionService
    {
        private readonly ICancionQuery _cancionQuery;
        private readonly ICervezaQuery _cervezaQuery;
        private readonly ICancionCommand _cancionCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<CancionService> _logger;

        public CancionService(ICancionQuery cancionQuery, ICancionCommand cancionCommand, IMapper mapper, ILogger<CancionService> logger, ICervezaQuery cervezaQuery)
        {
            _cancionQuery = cancionQuery;
            _cancionCommand = cancionCommand;
            _mapper = mapper;
            _logger = logger;
            _cervezaQuery = cervezaQuery;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            CancionResponse cuidadResponse = new CancionResponse();
            try
            {
                var cancion = await _cancionQuery.GetById(id);

                if (cancion == null)
                {
                    response.statusCode = 404;
                    response.message = "La cancion seleccionada no existe";
                    response.response = null;
                    return response;
                }

                List<Cerveza> cervezas = await _cervezaQuery.GetAll(0, 0, id, 0, false);

                if (cervezas.Any())
                {
                    response.statusCode = 409;
                    response.message = "No se puede eliminar la cancion porque posee al menos una cerveza asignada";
                    response.response = null;
                    return response;
                }

                await _cancionCommand.Delete(cancion);
                cuidadResponse = _mapper.Map<CancionResponse>(cancion);

                _logger.LogInformation("Se eliminó la cancion: " + id + ", " + cancion.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Cancion eliminada exitosamente";
            response.response = cuidadResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Cancion> lista = await _cancionQuery.GetAll();
                List<CancionResponse> listaDTO = _mapper.Map<List<CancionResponse>>(lista);

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
        public async Task<ResponseModel> Insert(CancionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CancionResponse cuidadResponse = new CancionResponse();
            try
            {
                Cancion cancion = _mapper.Map<Cancion>(entity);
                cancion = await _cancionCommand.Insert(cancion);
                cuidadResponse = _mapper.Map<CancionResponse>(cancion);

                _logger.LogInformation("Se insertó una nueva canción: " + cancion.Id + ". Nombre: " + cancion.Nombre);                
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Canción insertada exitosamente";
            response.response = cuidadResponse;
            return response;
        }

        public async Task<ResponseModel> Update(CancionRequest entity)
        {
            ResponseModel response = new ResponseModel();
            CancionResponse cancionResponse = new CancionResponse();
            try
            {
                var cancion = await _cancionQuery.GetById(entity.Id);

                if (cancion == null)
                {
                    response.statusCode = 404;
                    response.message = "La canción seleccionada no existe";
                    response.response = null;
                    return response;
                }

                if (entity.Solicitante == true && cancion.NombreSolicitante != "")
                {
                    response.statusCode = 403;
                    response.message = "La canción ya fue seleccionada por otro usuario";
                    response.response = null;
                    return response;
                }

                cancion.Nombre = entity.Nombre;
                cancion.Autor = entity.Autor;                
                cancion.Url = entity.Url;
                cancion.NombreSolicitante = entity.NombreSolicitante;
                cancion.Habilitado = entity.Habilitado;

                await _cancionCommand.Update(cancion);
                cancionResponse = _mapper.Map<CancionResponse>(cancion);

                _logger.LogInformation("Se actualizó la canción: " + cancion.Id + ". Nombre anterior: " + cancion.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Canción actualizada exitosamente";
            response.response = cancionResponse;
            return response;
        }


        public async Task<ResponseModel> Reset(List<int> ids)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var canciones = await _cancionQuery.GetAllById(ids);

                if (!canciones.Any())
                {
                    response.statusCode = 404;
                    response.message = "No se encontraron canciones";
                    response.response = null;
                    return response;
                }

                
                await _cancionCommand.Reset(ids);

                _logger.LogInformation("Se restablecieron las canciones");
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Canciones actualizadas exitosamente";            
            return response;
        }
    }
}
