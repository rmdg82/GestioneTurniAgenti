using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories.Contracts;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Controllers
{
    [ApiController]
    [Route("api/eventi")]
    public class EventiController : ControllerBase
    {
        private readonly ILogger<EventiController> _logger;
        private readonly IMapper _mapper;
        private readonly IEventiRepository _eventiRepository;

        public EventiController(ILogger<EventiController> logger, IMapper mapper, IEventiRepository eventiRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _eventiRepository = eventiRepository ?? throw new ArgumentNullException(nameof(eventiRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoDto>>> GetAllEventi([FromQuery] EventiSearchParameters parameters)
        {
            var eventi = await _eventiRepository.GetEventiFromParams(parameters);
            var eventiDto = _mapper.Map<IEnumerable<EventoDto>>(eventi);
            foreach (var eventoDto in eventiDto)
            {
                eventoDto.NumTurniLegati = await _eventiRepository.GetTurniLinkedToEvento(eventoDto.Id);
            }
            return Ok(eventiDto);
        }

        [HttpGet("{eventoId}", Name = "EventoById")]
        public async Task<ActionResult<EventoDto>> GetEventoById(Guid eventoId)
        {
            var evento = await _eventiRepository.GetById(eventoId);

            if (evento == null)
            {
                return NotFound();
            }

            var eventoDto = _mapper.Map<EventoDto>(evento);
            eventoDto.NumTurniLegati = await _eventiRepository.GetTurniLinkedToEvento(eventoId);

            return Ok(eventoDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento([FromBody] EventoForCreationDto eventoForCreation)
        {
            if (eventoForCreation == null)
            {
                _logger.LogError("EventoForCreationDto object sent is null.");
                return BadRequest("EventoForCreationDto object è nullo");
            }

            if (await _eventiRepository.CheckDuplicatedEvento(eventoForCreation.Inizio, eventoForCreation.Fine, eventoForCreation.Nome))
            {
                return BadRequest($"Evento con nome {eventoForCreation.Nome} esiste già nel database.");
            }

            var evento = _mapper.Map<Evento>(eventoForCreation);

            _eventiRepository.Create(evento);
            await _eventiRepository.Commit();

            var eventoToReturn = _mapper.Map<EventoDto>(evento);
            _logger.LogInformation($"Created new evento with id {eventoToReturn.Id}");

            return CreatedAtRoute("EventoById", new { eventoId = eventoToReturn.Id }, eventoToReturn);
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> UpdateEvento(Guid eventoId, [FromBody] EventoForUpdateDto eventoForUpdate)
        {
            if (eventoForUpdate == null)
            {
                _logger.LogError("EventoForUpdateDto object sent is null.");
                return BadRequest("EventoForUpdateDto object è nullo.");
            }

            var evento = await _eventiRepository.GetById(eventoId);
            if (evento == null)
            {
                return NotFound();
            }

            if (await _eventiRepository.CheckDuplicatedEvento(eventoForUpdate.Inizio, eventoForUpdate.Fine, eventoForUpdate.Nome))
            {
                return BadRequest($"Evento con nome {eventoForUpdate.Nome} esiste già nel database.");
            }

            if (await _eventiRepository.CheckInizioFineCompatibilityWithTurni(eventoId, eventoForUpdate.Inizio, eventoForUpdate.Fine, out int numTurni))
            {
                return BadRequest($"Modifica date inizio e fine dell'evento con nome {eventoForUpdate.Nome} non permessa. Lascierebbe {numTurni} turni senza evento di riferimento.");
            }

            _mapper.Map(eventoForUpdate, evento);
            await _eventiRepository.Commit();

            return NoContent();
        }

        [HttpDelete("{eventoId}")]
        public async Task<IActionResult> DeleteEvento(Guid eventoId)
        {
            var evento = await _eventiRepository.GetById(eventoId);
            if (evento == null)
            {
                return NotFound($"Evento con id {eventoId} non trovato nel database.");
            }

            if (await _eventiRepository.CheckTurniLinkedToEvento(eventoId, out int numTurni))
            {
                return BadRequest($"Ci sono ancora {numTurni} turni legati all'evento {evento.Nome} con id {eventoId}. Verificare dalla pagina dei turni.");
            }

            _eventiRepository.Delete(evento);
            await _eventiRepository.Commit();

            return NoContent();
        }
    }
}