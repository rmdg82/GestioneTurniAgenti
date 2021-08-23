using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Entities
{
    public class Turno : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid AgenteId { get; set; }
        public Agente Agente { get; set; }
        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }
        public DateTime Data { get; set; }
        public string Note { get; set; }
    }
}