using Domain.Models.GestorGastos;

namespace Application.Interfaces.GestorGastos.ICommands
{
    public interface IRegistroVinculadoCommand
    {
        Task<RegistroVinculado> Insert(RegistroVinculado entity);
        Task<RegistroVinculado> Update(RegistroVinculado entity);
        Task Delete(RegistroVinculado entity);
    }
}
