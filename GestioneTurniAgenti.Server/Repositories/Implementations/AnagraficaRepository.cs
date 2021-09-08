using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
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
    public class AnagraficaRepository : IAnagraficaRepository
    {
        private readonly GestioneTurniDbContext _context;

        public AnagraficaRepository(GestioneTurniDbContext DbContext)
        {
            _context = DbContext ?? throw new ArgumentNullException(nameof(DbContext));
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Agente> GetAgenteById(Guid agenteId)
        {
            return await _context.Set<Agente>().Include(a => a.Reparto).FirstOrDefaultAsync(a => a.Id.Equals(agenteId));
        }

        public async Task<IEnumerable<Agente>> GetAgenti(params Expression<Func<Agente, bool>>[] filters)
        {
            IQueryable<Agente> query = _context.Set<Agente>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            return await query.Include(a => a.Reparto).OrderBy(a => a.Cognome).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Agente>> GetAgentiFromParams(AgentiSearchParameters parameters, bool trackChanges = false)
        {
            IQueryable<Agente> query = _context.Set<Agente>().Include(a => a.Reparto);

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

            if (!string.IsNullOrWhiteSpace(parameters.Cognome))
            {
                query = query.Where(a => a.Cognome.ToUpper().Contains(parameters.Cognome.Trim().ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(parameters.Matricola))
            {
                query = query.Where(a => a.Matricola.ToUpper().Contains(parameters.Matricola.Trim().ToUpper()));
            }

            if (parameters.RepartoId != null)
            {
                query = query.Where(a => a.RepartoId.Equals(parameters.RepartoId));
            }

            query = query.OrderBy(a => a.Nome).ThenBy(a => a.Cognome);

            if (trackChanges)
            {
                return await query.ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Reparto>> GetReparti(params Expression<Func<Reparto, bool>>[] filters)
        {
            IQueryable<Reparto> query = _context.Set<Reparto>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Reparto> GetRepartoById(Guid repartoId)
        {
            return await _context.Set<Reparto>().FindAsync(repartoId);
        }
    }
}