using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Turno
{
    public class TurnoDto
    {
        public Guid Id { get; set; }
        public Guid AgenteId { get; set; }
        public string AgenteMatricola { get; set; }
        public string AgenteNome { get; set; }
        public string AgenteCognome { get; set; }
        public Guid AgenteRepartoId { get; set; }
        public string AgenteRepartoNome { get; set; }
        public Guid EventoId { get; set; }
        public string EventoNome { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
    }
}