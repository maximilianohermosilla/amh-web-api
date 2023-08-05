using amh_web_api.DTO;
using Application.DTO.GestorGastos;
using Application.Interfaces.GestorGastos.ICommands;
using Application.Interfaces.GestorGastos.IQueries;
using Application.Interfaces.GestorGastos.IServices;

namespace Application.Services.GestorGastos
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaQuery _empresaQuery;
        private readonly IEmpresaCommand _empresaCommand;

        public EmpresaService(IEmpresaQuery empresaQuery, IEmpresaCommand empresaCommand)
        {
            _empresaQuery = empresaQuery;
            _empresaCommand = empresaCommand;
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

        public Task<ResponseModel> Insert(EmpresaRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(EmpresaRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
