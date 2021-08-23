using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Turno
{
    public class TurnoForCreationDto
    {
        public Guid AgenteId { get; set; }
        public Guid EventoId { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
    }
}