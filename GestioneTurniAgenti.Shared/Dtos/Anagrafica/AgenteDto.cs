using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Anagrafica
{
    public class AgenteDto
    {
        public Guid Id { get; set; }
        public string Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Guid RepartoId { get; set; }
        public string NomeReparto { get; set; }
    }
}