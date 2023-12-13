using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TurnoRepository : GenericRepository<Turno>, ITurno
{
    private readonly PushUpContext  _context;
    public TurnoRepository(PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Turno> GetByIdAsync(int id)
    {
        return await _context.Turnos
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Turno>> GetAllAsync()
    {
        return await _context.Turnos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Turno> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Turnos as IQueryable<Turno>;
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