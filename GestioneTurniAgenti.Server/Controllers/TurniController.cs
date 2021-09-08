using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories.Contracts;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using GestioneTurniAgenti.Shared.SearchParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/turni")]
    [Authorize(Roles = "Admin,Super-Admin")]
    public class TurniController : ControllerBase
    {
        private readonly ILogger<TurniController> _logger;
        private readonly IMapper _mapper;
        private readonly ITurniRepository _turniRepository;

        public TurniController(ILogger<TurniController> logger, IMapper mapper, ITurniRepository turniRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _turniRepository = turniRepository ?? throw new ArgumentNullException(nameof(turniRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoDto>>> GetAllTurni([FromQuery] TurniSearchParameters searchParameters)
        {
            var turni = await _turniRepository.GetTurniByParams(searchParameters);

            return Ok(_mapper.Map<IEnumerable<TurnoDto>>(turni));
        }

        [HttpGet("{turnoId}", Name = "TurnoById")]
        public async Task<ActionResult<TurnoDto>> GetTurnoById(Guid turnoId)
        {
            var turno = await _turniRepository.GetTurnoById(turnoId, trackChanges: true);

            if (turno == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TurnoDto>(turno));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurno([FromBody] TurnoForCreationDto turnoForCreation)
        {
            if (turnoForCreation == null)
            {
                _logger.LogError("TurnoForCreationDto object sent is null.");
                return BadRequest("TurnoForCreationDto object è nullo.");
            }

            if (!await _turniRepository.CheckAgenteIdExistance(turnoForCreation.AgenteId))
            {
                return NotFound($"AgenteId {turnoForCreation.AgenteId} non trovato nel database.");
            }

            if (!await _turniRepository.CheckEventoIdExistance(turnoForCreation.EventoId))
            {
                return NotFound($"EventoId {turnoForCreation.EventoId} non trovato nel database.");
            }

            if (!await _turniRepository.CheckCompatibilityEventoWithData(turnoForCreation.EventoId, turnoForCreation.Data, out (DateTime max, DateTime min) values))
            {
                return BadRequest($"Evento con id {turnoForCreation.EventoId} non è compatibile con la data inserita {turnoForCreation.Data:dd/MM/yyyy}. Valori permessi tra {values.min:dd/MM/yyyy} e {values.max:dd/MM/yyyy}.");
            }

            if (await _turniRepository.CheckDuplicatedTurno(turnoForCreation.AgenteId, turnoForCreation.EventoId, turnoForCreation.Data))
            {
                return BadRequest($"Turno con agenteId {turnoForCreation.AgenteId}, eventoId {turnoForCreation.EventoId} and data {turnoForCreation.Data} esiste già nel database.");
            }

            var turno = _mapper.Map<Turno>(turnoForCreation);

            _turniRepository.Create(turno);
            await _turniRepository.Commit();

            var turnoToReturn = _mapper.Map<TurnoDto>(turno);
            _logger.LogInformation($"Created new turno with id {turnoToReturn.Id}");

            return CreatedAtRoute("TurnoById", new { turnoId = turnoToReturn.Id }, turnoToReturn);
        }

        [HttpPut("{turnoId}")]
        public async Task<IActionResult> UpdateTurno(Guid turnoId, [FromBody] TurnoForUpdateDto turnoForUpdate)
        {
            if (turnoForUpdate == null)
            {
                _logger.LogError("TurnoForUpdateDto object sent is null.");
                return BadRequest("TurnoForUpdateDto object è nullo.");
            }

            var turno = await _turniRepository.GetTurnoById(turnoId, trackChanges: true); ;
            if (turno == null)
            {
                return NotFound();
            }

            if (!await _turniRepository.CheckAgenteIdExistance(turnoForUpdate.AgenteId))
            {
                return NotFound($"AgenteId {turnoForUpdate.AgenteId} non trovato nel database.");
            }

            if (!await _turniRepository.CheckEventoIdExistance(turnoForUpdate.EventoId))
            {
                return NotFound($"EventoId {turnoForUpdate.EventoId} non trovato nel database.");
            }

            if (!await _turniRepository.CheckCompatibilityEventoWithData(turnoForUpdate.EventoId, turnoForUpdate.Data, out (DateTime max, DateTime min) values))
            {
                return BadRequest($"Evento {turnoForUpdate.EventoId} non è compatibile con la data inserita {turnoForUpdate.Data:dd/MM/yyyy}. Valori permessi tra {values.min:dd/MM/yyyy} e {values.max:dd/MM/yyyy}.");
            }

            _mapper.Map(turnoForUpdate, turno);
            await _turniRepository.Commit();

            return NoContent();
        }

        [HttpDelete("{turnoId}")]
        public async Task<IActionResult> DeleteTurno(Guid turnoId)
        {
            var turno = await _turniRepository.GetById(turnoId);

            if (turno == null)
            {
                return NotFound($"Turno con id {turnoId} non trovato nel database.");
            }

            _turniRepository.Delete(turno);
            await _turniRepository.Commit();

            return NoContent();
        }

        [HttpPost("massivo")]
        public IActionResult LoadTurniFromMassivo()
        {
            // Il servizio non è ancora implementato
            return StatusCode(503, "Servizio non ancora implementato.");
        }
    }
}