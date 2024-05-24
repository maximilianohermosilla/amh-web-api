using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using AutoMapper;
using Domain.Models.GestorGastos;
using Microsoft.Extensions.Logging;

namespace Application.Services.GestorGastos
{
    public class CategoriaGastoService : ICategoriaGastoService
    {
        private readonly ICategoriaGastoQuery _CategoriaGastoQuery;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoriaGastoService> _logger;

        public CategoriaGastoService(ICategoriaGastoQuery CategoriaGastoQuery, IMapper mapper, ILogger<CategoriaGastoService> logger)
        {
            _CategoriaGastoQuery = CategoriaGastoQuery;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponseModel> GetAll()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                List<CategoriaGasto> lista = await _CategoriaGastoQuery.GetAll();
                List<CategoriaGastoResponse> listaDTO = _mapper.Map<List<CategoriaGastoResponse>>(lista);

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


        public async Task<ResponseModel> GetById(int? IdCategoriaGasto)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                CategoriaGasto CategoriaGasto = await _CategoriaGastoQuery.GetById(IdCategoriaGasto);

                if (CategoriaGasto == null)
                {
                    response.statusCode = 404;
                    response.message = "La Categoria seleccionada no existe";
                    response.response = null;
                    return response;
                }

                CategoriaGastoResponse CategoriaGastoResponse = _mapper.Map<CategoriaGastoResponse>(CategoriaGasto);

                response.message = "Consulta realizada correctamente";
                response.statusCode = 200;
                response.response = CategoriaGastoResponse;
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = ex.Message;
                response.response = null;
            }

            return response;
        }
    }
}
