using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Application.Interfaces.MayiBeerCollection.IQueries;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorGastos
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaQuery _empresaQuery;
        private readonly IEmpresaCommand _empresaCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<EmpresaService> _logger;

        public EmpresaService(IEmpresaQuery empresaQuery, IEmpresaCommand empresaCommand, IMapper mapper, ILogger<EmpresaService> logger, ICervezaQuery cervezaQuery)
        {
            _empresaQuery = empresaQuery;
            _empresaCommand = empresaCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                var empresa = await _empresaQuery.GetById(id);

                if (empresa == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionada no existe";
                    response.response = null;
                    return response;
                }

                await _empresaCommand.Delete(empresa);
                empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                _logger.LogInformation("Se eliminó la empresa: " + id + ", " + empresa.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Empresa eliminada exitosamente";
            response.response = empresaResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Empresa> lista = await _empresaQuery.GetAll();
                List<EmpresaResponse> listaDTO = _mapper.Map<List<EmpresaResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdEmpresa)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Empresa empresa = await _empresaQuery.GetById(IdEmpresa);

                if (empresa == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionada no existe";
                    response.response = null;
                    return response;
                }

                EmpresaResponse EmpresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = EmpresaResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(EmpresaRequest entity)
        {
            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                Empresa empresa = _mapper.Map<Empresa>(entity);
                empresa = await _empresaCommand.Insert(empresa);
                empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                _logger.LogInformation("Se insertó una nueva empresa: " + empresa.Id + ". Nombre: " + empresa.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Empresa insertada exitosamente";
            response.response = empresaResponse;
            return response;
        }


        public async Task<ResponseModel> Update(EmpresaRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            EmpresaResponse empresaResponse = new EmpresaResponse();
            try
            {
                var empresa = await _empresaQuery.GetById(id);

                if (empresa == null)
                {
                    response.statusCode = 404;
                    response.message = "La empresa seleccionada no existe";
                    response.response = null;
                    return response;
                }

                empresa.Nombre = entity.Nombre;

                await _empresaCommand.Update(empresa);
                empresaResponse = _mapper.Map<EmpresaResponse>(empresa);

                _logger.LogInformation("Se actualizó la empresa: " + empresa.Id + ". Nombre anterior: " + empresa.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Empresa actualizada exitosamente";
            response.response = empresaResponse;
            return response;
        }
    }
}