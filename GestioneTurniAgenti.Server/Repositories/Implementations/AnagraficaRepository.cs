using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories.Contracts;
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

            return await query.OrderBy(a => a.Nome).AsNoTracking().ToListAsync();
        }

        public async Task<Reparto> GetRepartoById(Guid repartoId)
        {
            return await _context.Set<Reparto>().FindAsync(repartoId);
        }
    }
}