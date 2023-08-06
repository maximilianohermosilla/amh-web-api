using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;
using AutoMapper;
using Domain.Models;
using Domain.Models.MayiBeerCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.MayiBeerCollection
{
    public class EstiloService : IEstiloService
    {
        private readonly IEstiloQuery _estiloQuery;
        private readonly ICervezaQuery _cervezaQuery;
        private readonly IEstiloCommand _estiloCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<EstiloService> _logger;

        public EstiloService(IEstiloQuery estiloQuery, IEstiloCommand estiloCommand, IMapper mapper, ILogger<EstiloService> logger, ICervezaQuery cervezaQuery)
        {
            _estiloQuery = estiloQuery;
            _estiloCommand = estiloCommand;
            _mapper = mapper;
            _logger = logger;
            _cervezaQuery = cervezaQuery;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            EstiloResponse estiloResponse = new EstiloResponse();
            try
            {
                var estilo = await _estiloQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "El estilo seleccionado no existe";
                    response.response = null;
                    return response;
                }

                List<Cerveza> cervezas = await _cervezaQuery.GetAll(0, id, 0, 0, false);
                
                if (cervezas.Any())
                {
                    response.statusCode = 409;
                    response.message = "No se puede eliminar el estilo porque posee al menos una cerveza asignada";
                    response.response = null;
                    return response;
                }

                await _estiloCommand.Delete(estilo);
                estiloResponse = _mapper.Map<EstiloResponse>(estilo);

                _logger.LogInformation("Se eliminó el estilo: " + id + ", " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Estilo eliminado exitosamente";
            response.response = estiloResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Estilo> lista = await _estiloQuery.GetAll();
                List<EstiloResponse> listaDTO = _mapper.Map<List<EstiloResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdEstilo)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Estilo estilo = await _estiloQuery.GetById(IdEstilo);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "El estilo seleccionado no existe";
                    response.response = null;
                    return response;
                }

                EstiloResponse EstiloResponse = _mapper.Map<EstiloResponse>(estilo);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = EstiloResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(EstiloRequest entity)
        {
            ResponseModel response = new ResponseModel();
            EstiloResponse estiloResponse = new EstiloResponse();
            try
            {
                Estilo estilo = _mapper.Map<Estilo>(entity);
                estilo = await _estiloCommand.Insert(estilo);
                estiloResponse = _mapper.Map<EstiloResponse>(estilo);

                _logger.LogInformation("Se insertó un nuevo estilo: " + estilo.Id + ". Nombre: " + estilo.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Estilo insertado exitosamente";
            response.response = estiloResponse;
            return response;
        }


        public async Task<ResponseModel> Update(EstiloRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            EstiloResponse estiloResponse = new EstiloResponse();
            try
            {
                var estilo = await _estiloQuery.GetById(id);

                if (estilo == null)
                {
                    response.statusCode = 404;
                    response.message = "El estilo seleccionado no existe";
                    response.response = null;
                    return response;
                }

                estilo.Nombre = entity.Nombre;
                estilo.Imagen = entity.Imagen;

                await _estiloCommand.Update(estilo);
                estiloResponse = _mapper.Map<EstiloResponse>(estilo);

                _logger.LogInformation("Se actualizó el estilo: " + estilo.Id + ". Nombre anterior: " + estilo.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Estilo actualizado exitosamente";
            response.response = estiloResponse;
            return response;
        }
    }
}
