using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IEmpresaCommand
    {
        Task<Empresa> Insert(Empresa entity);
        Task<Empresa> Update(Empresa entity);
        Task Delete(Empresa entity);
    }
}
