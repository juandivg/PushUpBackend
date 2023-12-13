using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly PushUpContext _context;
    public CiudadRepository( PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Ciudad> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Ciudades as IQueryable<Ciudad>;
        if (!string.IsNullOrEmpty(search))
        {
             query = query.Where(p => p.nombreCiudad.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query
                                 .Skip((pageIndex - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        return (totalRegistros, registros);
    }
}