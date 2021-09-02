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
            //var evento = await _context.Eventi
            //    .FirstOrDefaultAsync(
            //        e => e.Nome.Equals(nome) &&
            //        e.Inizio.Date.Equals(inizio.Date) &&
            //        e.Fine.Date.Equals(fine.Date));

            // Check only events with duplicated name
            var evento = await _context.Eventi.FirstOrDefaultAsync(e => e.Nome.Equals(nome));

            return evento != null;
        }

        public Task<bool> CheckInizioFineCompatibilityWithTurni(Guid eventoId, DateTime inizio, DateTime fine, out int numTurni)
        {
            numTurni = 0;

            var evento = _context.Eventi.Find(eventoId);

            if (evento == null)
            {
                return Task.FromResult(false);
            }

            var turni = _context.Turni.Where(t => t.EventoId.Equals(eventoId)).ToList();

            foreach (var turno in turni)
            {
                if (turno.Data < inizio || turno.Data > fine)
                {
                    numTurni++;
                }
            }

            return Task.FromResult(numTurni > 0);
        }

        public Task<bool> CheckTurniLinkedToEvento(Guid eventoId, out int numTurni)
        {
            numTurni = 0;
            Evento evento = _context.Eventi.Find(eventoId);
            if (evento == null)
            {
                return Task.FromResult(false);
            }

            var turni = _context.Turni.Where(t => t.EventoId.Equals(eventoId)).ToList();
            numTurni = turni.Count;

            return Task.FromResult(turni.Any());
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
                query = query.Where(e => e.Nome.ToUpper().Contains(parameters.Nome.Trim().ToUpper()));
            }

            if (!string.IsNullOrWhiteSpace(parameters.MatricolaAgente))
            {
                var agentiIdFromMatricola = await _context.Agenti
                    .Where(a => a.Matricola.ToUpper().Contains(parameters.MatricolaAgente.Trim().ToUpper()))
                    .Select(a => a.Id)
                    .ToListAsync();

                var turniFromAgenti = new List<Turno>();
                foreach (Guid agenteId in agentiIdFromMatricola)
                {
                    var turni = await _context.Turni.Where(t => t.AgenteId.Equals(agenteId)).ToListAsync();
                    if (turni != null)
                    {
                        foreach (var turno in turni)
                        {
                            turniFromAgenti.Add(turno);
                        }
                    }
                }

                var eventiIdFromTurni = turniFromAgenti.Select(t => t.EventoId).ToList();

                query = query.Where(e => eventiIdFromTurni.Contains(e.Id));
            }

            if (trackChanges)
            {
                return await query.ToListAsync();
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTurniLinkedToEvento(Guid eventoId)
        {
            var linkedTurni = await _context.Turni.Where(t => t.EventoId.Equals(eventoId)).ToListAsync();

            return linkedTurni.Count;
        }
    }
}