using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services.Implementations
{
    public class EventiRepository : BaseRepository<Evento>, IEventiRepository
    {
        public EventiRepository(GestioneTurniDbContext dbContext)
            : base(dbContext)
        {
        }

        //private readonly GestioneTurniDbContext _context;

        //public EventiRepository(GestioneTurniDbContext DbContext)
        //{
        //    _context = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        //}

        //public void AddEvento(Evento evento)
        //{
        //    _context.Set<Evento>().Add(evento);
        //}

        //public async Task<bool> Commit()
        //{
        //    return await _context.SaveChangesAsync() > 0;
        //}

        //public void DeleteEvento(Evento evento)
        //{
        //    _context.Set<Evento>().Remove(evento);
        //}

        //public async Task<IEnumerable<Evento>> GetEventi(params Expression<Func<Evento, bool>>[] filters)
        //{
        //    IQueryable<Evento> query = _context.Set<Evento>();

        //    if (filters != null)
        //    {
        //        foreach (var filter in filters)
        //        {
        //            query = query.Where(filter);
        //        }
        //    }

        //    return await query.AsNoTracking().ToListAsync();
        //}

        //public async Task<Evento> GetEventoById(Guid eventoId)
        //{
        //    return await _context.Set<Evento>().FindAsync(eventoId);
        //}

        //public void UpdateEvento(Evento evento)
        //{
        //    _context.Set<Evento>().Update(evento);
        //}
    }
}