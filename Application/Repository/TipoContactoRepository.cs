using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class TipoContactoRepository : GenericRepository<TipoContacto>, ITipoContacto
{
    private readonly PushUpContext  _context;
    public TipoContactoRepository( PushUpContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<TipoContacto> GetByIdAsync(int id)
    {
        return await _context.TipoContactos
                            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<TipoContacto>> GetAllAsync()
    {
        return await _context.TipoContactos.ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<TipoContacto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.TipoContactos as IQueryable<TipoContacto>;
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