using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Eventi
{
    public class EventoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
        public int NumTurniLegati { get; set; }
    }
}