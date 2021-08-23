using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Entities
{
    public class Agente
    {
        public Guid Id { get; set; }
        public string Matricola { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Reparto Reparto { get; set; }
        public Guid RepartoId { get; set; }
    }
}