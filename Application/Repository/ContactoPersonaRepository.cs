using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ContactoPersonaRepository : GenericRepository<ContactoPersona>, IContactoPersona
{
    private readonly PushUpContext  _context;
    public ContactoPersonaRepository( PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ContactoPersona> GetByIdAsync(int id)
    {
        return await _context.ContactoPersonas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<ContactoPersona>> GetAllAsync()
    {
        return await _context.ContactoPersonas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<ContactoPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.ContactoPersonas as IQueryable<ContactoPersona>;
        if (!string.IsNullOrEmpty(search))
        {
            // query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<ContactoPersona>> GetContactosVigilante()
    {
        return await _context.ContactoPersonas.Where(c=>c.Persona.IdCat==1).ToListAsync();
    }
}