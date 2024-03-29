﻿using amh_web_api.DTO;
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
    public class PaisService: IPaisService
    {
        private readonly IPaisQuery _paisQuery;
        private readonly ICervezaQuery _cervezaQuery;
        private readonly IPaisCommand _paisCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<PaisService> _logger;

        public PaisService(IPaisQuery paisQuery, IPaisCommand paisCommand, IMapper mapper, ILogger<PaisService> logger, ICervezaQuery cervezaQuery)
        {
            _paisQuery = paisQuery;
            _paisCommand = paisCommand;
            _mapper = mapper;
            _logger = logger;
            _cervezaQuery = cervezaQuery;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            PaisResponse paisResponse = new PaisResponse();
            try
            {
                var pais = await _paisQuery.GetById(id);

                if (pais == null)
                {
                    response.statusCode = 404;
                    response.message = "El país seleccionado no existe";
                    response.response = null;
                    return response;
                }

                List<Cerveza> cervezas = await _cervezaQuery.GetAll(0, 0, 0, id, false);

                if (cervezas.Any())
                {
                    response.statusCode = 409;
                    response.message = "No se puede eliminar el país porque posee al menos una cerveza asignada";
                    response.response = null;
                    return response;
                }

                await _paisCommand.Delete(pais);
                paisResponse = _mapper.Map<PaisResponse>(pais);

                _logger.LogInformation("Se eliminó el país: " + id + ", " + pais.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "País eliminado exitosamente";
            response.response = paisResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {  
                List<Pais> lista = await _paisQuery.GetAll();
                List<PaisResponse> listaDTO = _mapper.Map<List<PaisResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdPais)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Pais pais = await _paisQuery.GetById(IdPais);

                if (pais == null)
                {
                    response.statusCode = 404;
                    response.message = "El país seleccionado no existe";
                    response.response = null;
                    return response;
                }

                PaisResponse paisResponse = _mapper.Map<PaisResponse>(pais);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = paisResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(PaisRequest entity)
        {
            ResponseModel response = new ResponseModel();
            PaisResponse paisResponse = new PaisResponse();
            try
            {
                Pais pais = _mapper.Map<Pais>(entity);
                pais = await _paisCommand.Insert(pais);
                paisResponse = _mapper.Map<PaisResponse>(pais);

                _logger.LogInformation("Se insertó un nuevo país: " + pais.Id + ". Nombre: " + pais.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "País insertado exitosamente";
            response.response = paisResponse;
            return response;
        }


        public async Task<ResponseModel> Update(PaisRequest entity)
        {
            ResponseModel response = new ResponseModel();
            PaisResponse paisResponse = new PaisResponse();
            try
            {
                var pais = await _paisQuery.GetById(entity.Id);

                if (pais == null)
                {
                    response.statusCode = 404;
                    response.message = "El país seleccionado no existe";
                    response.response = null;
                    return response;
                }

                pais.Nombre = entity.Nombre;
                pais.Imagen = entity.Imagen;

                await _paisCommand.Update(pais);
                paisResponse = _mapper.Map<PaisResponse>(pais);

                _logger.LogInformation("Se actualizó el país: " + pais.Id + ". Nombre anterior: " + pais.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "País actualizado exitosamente";
            response.response = paisResponse;
            return response;
        }
    }
}
