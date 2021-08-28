using System;

namespace GestioneTurniAgenti.Shared.SearchParameters
{
    public class AgentiSearchParameters
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Matricola { get; set; }
        public Guid? RepartoId { get; set; }
    }
}