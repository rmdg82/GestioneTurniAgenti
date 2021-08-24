using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Services.Contracts;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
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
        public async Task<ActionResult<IEnumerable<EventoDto>>> GetAll()
        {
            var eventi = await _eventiRepository.GetByFilter();
            return Ok(_mapper.Map<IEnumerable<EventoDto>>(eventi));
        }

        [HttpGet("{eventoId}", Name = "EventoById")]
        public async Task<ActionResult<EventoDto>> GetEventoById(Guid eventoId)
        {
            var evento = await _eventiRepository.GetById(eventoId);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EventoDto>(evento));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvento([FromBody] EventoForCreationDto eventoForCreation)
        {
            if (eventoForCreation == null)
            {
                _logger.LogError("EventoForCreationDto object sent is null.");
                return BadRequest("EventoForCreationDto object sent is null");
            }

            if (await _eventiRepository.CheckDuplicatedEvento(eventoForCreation.Inizio, eventoForCreation.Fine, eventoForCreation.Nome))
            {
                return BadRequest($"Evento with name {eventoForCreation.Nome}, data inizio {eventoForCreation.Inizio.Date}, data fine {eventoForCreation.Fine.Date} already exists in the database.");
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
                return BadRequest("EventoForUpdateDto object is null");
            }

            var evento = await _eventiRepository.GetById(eventoId);
            if (evento == null)
            {
                return NotFound();
            }

            if (await _eventiRepository.CheckDuplicatedEvento(eventoForUpdate.Inizio, eventoForUpdate.Fine, eventoForUpdate.Nome))
            {
                return BadRequest($"Evento with name {eventoForUpdate.Nome}, data inizio {eventoForUpdate.Inizio.Date}, data fine {eventoForUpdate.Fine.Date} already exists in the database.");
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
                return NotFound($"Cannot found evento with id {eventoId} on the database.");
            }

            if (await _eventiRepository.CheckTurniLinkedToEvento(eventoId))
            {
                return BadRequest($"There are some still Turni linked to the evento {eventoId}.");
            }

            _eventiRepository.Delete(evento);
            await _eventiRepository.Commit();

            return NoContent();
        }
    }
}