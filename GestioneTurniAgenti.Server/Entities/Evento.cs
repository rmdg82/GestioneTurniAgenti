using System;

namespace GestioneTurniAgenti.Server.Entities
{
    public class Evento : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }
    }
}