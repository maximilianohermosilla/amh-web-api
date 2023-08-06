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
    public class BancoService: IBancoService
    {
        private readonly IBancoQuery _bancoQuery;
        private readonly IBancoCommand _bancoCommand;
        private readonly IMapper _mapper;
        private readonly ILogger<BancoService> _logger;

        public BancoService(IBancoQuery bancoQuery, IBancoCommand bancoCommand, IMapper mapper, ILogger<BancoService> logger, ICervezaQuery cervezaQuery)
        {
            _bancoQuery = bancoQuery;
            _bancoCommand = bancoCommand;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            BancoResponse bancoResponse = new BancoResponse();
            try
            {
                var banco = await _bancoQuery.GetById(id);

                if (banco == null)
                {
                    response.statusCode = 404;
                    response.message = "El banco seleccionado no existe";
                    response.response = null;
                    return response;
                }

                await _bancoCommand.Delete(banco);
                bancoResponse = _mapper.Map<BancoResponse>(banco);

                _logger.LogInformation("Se eliminó el banco: " + id + ", " + banco.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            response.statusCode = 200;
            response.message = "Banco eliminado exitosamente";
            response.response = bancoResponse;
            return response;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<Banco> lista = await _bancoQuery.GetAll();
                List<BancoResponse> listaDTO = _mapper.Map<List<BancoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdBanco)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                Banco banco = await _bancoQuery.GetById(IdBanco);

                if (banco == null)
                {
                    response.statusCode = 404;
                    response.message = "El banco seleccionado no existe";
                    response.response = null;
                    return response;
                }

                BancoResponse BancoResponse = _mapper.Map<BancoResponse>(banco);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = BancoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }

        public async Task<ResponseModel> Insert(BancoRequest entity)
        {
            ResponseModel response = new ResponseModel();
            BancoResponse bancoResponse = new BancoResponse();
            try
            {
                Banco banco = _mapper.Map<Banco>(entity);
                banco = await _bancoCommand.Insert(banco);
                bancoResponse = _mapper.Map<BancoResponse>(banco);

                _logger.LogInformation("Se insertó un nuevo banco: " + banco.Id + ". Nombre: " + banco.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 201;
            response.message = "Banco insertado exitosamente";
            response.response = bancoResponse;
            return response;
        }


        public async Task<ResponseModel> Update(BancoRequest entity, int id)
        {
            ResponseModel response = new ResponseModel();
            BancoResponse bancoResponse = new BancoResponse();
            try
            {
                var banco = await _bancoQuery.GetById(id);

                if (banco == null)
                {
                    response.statusCode = 404;
                    response.message = "El banco seleccionado no existe";
                    response.response = null;
                    return response;
                }

                banco.Nombre = entity.Nombre;

                await _bancoCommand.Update(banco);
                bancoResponse = _mapper.Map<BancoResponse>(banco);

                _logger.LogInformation("Se actualizó el banco: " + banco.Id + ". Nombre anterior: " + banco.Nombre + ". Nombre actual: " + entity.Nombre);
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
                return response;
            }

            response.statusCode = 200;
            response.message = "Banco actualizado exitosamente";
            response.response = bancoResponse;
            return response;
        }
    }
}
