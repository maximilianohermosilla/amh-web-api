using amh_web_api.DTO;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;
using Domain.Models.GestorGastos;

namespace Application.Services.GestorGastos
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaQuery _cuentaQuery;
        private readonly ICuentaCommand _cuentaCommand;

        public CuentaService(ICuentaQuery cuentaQuery, ICuentaCommand cuentaCommand)
        {
            _cuentaQuery = cuentaQuery;
            _cuentaCommand = cuentaCommand;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(Cuenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(Cuenta entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
