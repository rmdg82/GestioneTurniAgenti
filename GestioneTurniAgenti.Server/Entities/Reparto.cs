using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;

namespace GestioneTurniAgenti.Server.Entities
{
    public class Reparto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Agente> Agenti { get; set; } = new List<Agente>();
    }
}