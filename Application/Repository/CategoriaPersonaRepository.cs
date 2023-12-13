using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class CategoriaPersonaRepository : GenericRepository<CategoriaPersona>, ICategoriaPersona
{
    private readonly PushUpContext _context;
    public CategoriaPersonaRepository( PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<CategoriaPersona> GetByIdAsync(int id)
    {
        return await _context.CategoriaPersonas
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<CategoriaPersona>> GetAllAsync()
    {
        return await _context.CategoriaPersonas.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<CategoriaPersona> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.CategoriaPersonas as IQueryable<CategoriaPersona>;
        if (!string.IsNullOrEmpty(search))
        {
             //query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
}