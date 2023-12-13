using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class DirPersonaRepository : GenericRepository<DirPersona>, IDirPersona
{
    private readonly PushUpContext _context;
    public DirPersonaRepository(PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<DirPersona> GetByIdAsync(int id)
    {
        return await _context.DirPersonas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<DirPersona>> GetAllAsync()
    {
        return await _context.DirPersonas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<DirPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.DirPersonas as IQueryable<DirPersona>;
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
}