using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersona : IGeneric<Persona>
    {
        Task<IEnumerable<Persona>> GetEmpleados();
        Task<IEnumerable<Persona>> GetVigilantes();
        Task<IEnumerable<Persona>> GetClientesBucaramanga();

    }
}