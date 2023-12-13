using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContactoPersona : IGeneric<ContactoPersona>
    {
        Task<IEnumerable<ContactoPersona>> GetContactosVigilante();
    }
}