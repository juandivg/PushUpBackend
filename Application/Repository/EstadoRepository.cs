using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class EstadoRepository : GenericRepository<Estado>, IEstado
{
    private readonly PushUpContext  _context;
    public EstadoRepository( PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Estado> GetByIdAsync(int id)
    {
        return await _context.Estados
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Estado>> GetAllAsync()
    {
        return await _context.Estados.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Estado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Estados as IQueryable<Estado>;
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