using AutoMapper;
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
    }
}