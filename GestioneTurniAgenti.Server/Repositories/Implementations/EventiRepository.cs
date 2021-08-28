using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories;
using GestioneTurniAgenti.Server.Repositories.Contracts;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Repositories.Implementations
{
    public class EventiRepository : BaseRepository<Evento>, IEventiRepository
    {
        private readonly GestioneTurniDbContext _context;

        public EventiRepository(GestioneTurniDbContext dbContext)
            : base(dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> CheckDuplicatedEvento(DateTime inizio, DateTime fine, string nome)
        {
            var evento = await _context.Eventi
                .FirstOrDefaultAsync(
                    e => e.Nome.Equals(nome) &&
                    e.Inizio.Date.Equals(inizio.Date) &&
                    e.Fine.Date.Equals(fine.Date));

            return evento != null;
        }

        public async Task<bool> CheckTurniLinkedToEvento(Guid eventoId)
        {
            var evento = await _context.Eventi.FindAsync(eventoId);
            if (evento == null)
            {
                return false;
            }

            var turni = await _context.Turni.Where(t => t.EventoId.Equals(eventoId)).ToListAsync();

            return turni.Any();
        }

        public async Task<IEnumerable<Evento>> GetEventiFromParams(EventiSearchParameters parameters, bool trackChanges = false)
        {
            IQueryable<Evento> query = _context.Set<Evento>();

            if (parameters is null)
            {
                if (trackChanges)
                {
                    return await query.ToListAsync();
                }

                return await query.AsNoTracking().ToListAsync();
            }

            if (!string.IsNullOrWhiteSpace(parameters.Nome))
            {
                query = query.Where(a => a.Nome.ToUpper().Contains(parameters.Nome.Trim().ToUpper()));
            }

            if (trackChanges)
            {
                return await query.ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }
    }
}