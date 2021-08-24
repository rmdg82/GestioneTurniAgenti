using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Services.Contracts;
using GestioneTurniAgenti.Shared.Dtos.Turno;
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
        public async Task<ActionResult<IEnumerable<TurnoDto>>> GetAllTurni()
        {
            var turni = await _turniRepository.GetByFilterWithNavigationProps();

            return Ok(_mapper.Map<IEnumerable<TurnoDto>>(turni));
        }

        [HttpGet("{turnoId}", Name = "TurnoById")]
        public async Task<ActionResult<TurnoDto>> GetTurnoById(Guid turnoId)
        {
            var turno = await _turniRepository.GetById(turnoId);

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
                return BadRequest("TurnoForCreationDto object is null");
            }

            if (!await _turniRepository.CheckAgenteIdExistance(turnoForCreation.AgenteId))
            {
                return NotFound($"Cannot found AgenteId {turnoForCreation.AgenteId} on the database.");
            }

            if (!await _turniRepository.CheckEventoIdExistance(turnoForCreation.EventoId))
            {
                return NotFound($"Cannot found EventoId {turnoForCreation.EventoId} on the database.");
            }

            if (!await _turniRepository.CheckCompatibilityEventoWithData(turnoForCreation.EventoId, turnoForCreation.Data))
            {
                return BadRequest($"Evento {turnoForCreation.EventoId} is not compatible with date {turnoForCreation.Data}");
            }

            if (await _turniRepository.CheckDuplicatedTurno(turnoForCreation.AgenteId, turnoForCreation.EventoId, turnoForCreation.Data))
            {
                return BadRequest($"Turno with agenteId {turnoForCreation.AgenteId}, eventoId {turnoForCreation.EventoId} and data {turnoForCreation.Data} already exists in the database.");
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
                return BadRequest("TurnoForUpdateDto object is null");
            }

            var turno = await _turniRepository.GetById(turnoId);
            if (turno == null)
            {
                return NotFound();
            }

            if (!await _turniRepository.CheckAgenteIdExistance(turnoForUpdate.AgenteId))
            {
                return NotFound($"Cannot found AgenteId {turnoForUpdate.AgenteId} on the database.");
            }

            if (!await _turniRepository.CheckEventoIdExistance(turnoForUpdate.EventoId))
            {
                return NotFound($"Cannot found EventoId {turnoForUpdate.EventoId} on the database.");
            }

            if (!await _turniRepository.CheckCompatibilityEventoWithData(turnoForUpdate.EventoId, turnoForUpdate.Data))
            {
                return BadRequest($"Evento {turnoForUpdate.EventoId} is not compatible with date {turnoForUpdate.Data}");
            }

            if (await _turniRepository.CheckDuplicatedTurno(turnoForUpdate.AgenteId, turnoForUpdate.EventoId, turnoForUpdate.Data))
            {
                return BadRequest($"Turno with agenteId {turnoForUpdate.AgenteId}, eventoId {turnoForUpdate.EventoId} and data {turnoForUpdate.Data} already exists.");
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
                return NotFound($"Cannot found turno with id {turnoId} on the database.");
            }

            _turniRepository.Delete(turno);
            await _turniRepository.Commit();

            return NoContent();
        }
    }
}