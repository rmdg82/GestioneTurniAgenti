using AutoMapper;
using GestioneTurniAgenti.Server.Repositories.Contracts;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
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
    [Route("api/anagrafica")]
    public class AnagraficaController : ControllerBase
    {
        private readonly ILogger<AnagraficaController> _logger;
        private readonly IMapper _mapper;
        private readonly IAnagraficaRepository _anagraficaRepository;

        public AnagraficaController(ILogger<AnagraficaController> logger, IMapper mapper, IAnagraficaRepository anagraficaRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _anagraficaRepository = anagraficaRepository ?? throw new ArgumentNullException(nameof(anagraficaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("agenti")]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAllAgenti([FromQuery] AgentiSearchParameters searchParameters)
        {
            var agenti = await _anagraficaRepository.GetAgentiFromParams(searchParameters);

            return Ok(_mapper.Map<IEnumerable<AgenteDto>>(agenti));
        }

        [HttpGet("agenti/{agenteId}")]
        public async Task<ActionResult<AgenteDto>> GetAgenteById(Guid agenteId)
        {
            var agente = await _anagraficaRepository.GetAgenteById(agenteId);

            if (agente == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AgenteDto>(agente));
        }

        [HttpGet("reparti")]
        public async Task<ActionResult<IEnumerable<RepartoDto>>> GetAllReparti()
        {
            var reparti = await _anagraficaRepository.GetReparti();

            return Ok(_mapper.Map<IEnumerable<RepartoDto>>(reparti));
        }

        [HttpGet("reparti/{repartoId}")]
        public async Task<ActionResult<RepartoDto>> GetRepartoById(Guid repartoId)
        {
            var reparto = await _anagraficaRepository.GetRepartoById(repartoId);

            if (reparto == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RepartoDto>(reparto));
        }

        [HttpGet("reparti/{repartoId}/agenti")]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgentiByRepartoId(Guid repartoId)
        {
            var agenti = await _anagraficaRepository.GetAgenti(a => a.RepartoId.Equals(repartoId));

            return Ok(_mapper.Map<IEnumerable<AgenteDto>>(agenti));
        }
    }
}