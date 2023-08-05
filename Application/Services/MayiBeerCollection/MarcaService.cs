using amh_web_api.DTO;
using Application.DTO.MayiBeerCollection;
using Application.Interfaces.MayiBeerCollection.ICommands;
using Application.Interfaces.MayiBeerCollection.IQueries;
using Application.Interfaces.MayiBeerCollection.IServices;
using AutoMapper;
using Domain.Models.MayiBeerCollection;
using Microsoft.Extensions.Logging;

namespace Application.Services.MayiBeerCollection
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaQuery _marcaQuery;
        private readonly IMarcaCommand _marcaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<MarcaService> _logger;

        public MarcaService(IMarcaQuery marcaQuery, IMarcaCommand marcaCommand, IMapper mapper, ILogger<MarcaService> logger)
        {
            _marcaQuery = marcaQuery;
            _marcaCommand = marcaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            MarcaResponse marcaResponse = new MarcaResponse();
            try
            {
                var marca = await _marcaQuery.GetById(id);

                if (marca == null)
                {
                    response.statusCode = 404;
                    response.message = "La marca seleccionada no existe";
                    response.response = null;
                    return response;
                }

                //List<Cerveza> _cervezas = (from tbl in _contexto.Cerveza where tbl.IdCiudad == CiudadId select tbl).ToList();
                //if (_cervezas.Count() > 0)
                //{
                //    return BadRequest("No se puede eliminar la ciudad porque tiene una o más cervezas asociadas");
                //}

                await _marcaCommand.Delete(marca);
                marcaResponse = _mapper.Map<MarcaResponse>(marca);

                _logger.LogInformation("Se eliminó la marca: " + id + ", " + marca.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Marca eliminada exitosamente";
            response.response = marcaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Marca> lista = await _marcaQuery.GetAll();
                List<MarcaResponse> listaDTO = _mapper.Map<List<MarcaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdMarca)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Marca marca = await _marcaQuery.GetById(IdMarca);

                if (marca == null)
                {
                    response.statusCode = 404;
                    response.message = "La marca seleccionada no existe";
                    response.response = null;
                    return response;
                }

                MarcaResponse MarcaResponse = _mapper.Map<MarcaResponse>(marca);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = MarcaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(MarcaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            MarcaResponse marcaResponse = new MarcaResponse();
            try
            {
                Marca marca = _mapper.Map<Marca>(entity);
                marca = await _marcaCommand.Insert(marca);
                marcaResponse = _mapper.Map<MarcaResponse>(marca);

                _logger.LogInformation("Se insertó una nueva marca: " + marca.Id + ". Nombre: " + marca.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Marca insertada exitosamente";
            response.response = marcaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(MarcaRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            MarcaResponse marcaResponse = new MarcaResponse();
            try
            {
                var marca = await _marcaQuery.GetById(id);

                if (marca == null)
                {
                    response.statusCode = 404;
                    response.message = "La marca seleccionada no existe";
                    response.response = null;
                    return response;
                }

                marca.Nombre = entity.Nombre;
                marca.Imagen = entity.Imagen;

                await _marcaCommand.Update(marca);
                marcaResponse = _mapper.Map<MarcaResponse>(marca);

                _logger.LogInformation("Se actualizó la marca: " + marca.Id + ". Nombre anterior: " + marca.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Marca actualizada exitosamente";
            response.response = marcaResponse;
            return response;
        }
    }
}
