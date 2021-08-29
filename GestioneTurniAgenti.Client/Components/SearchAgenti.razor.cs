using GestioneTurniAgenti.Shared.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Components
{
    public partial class SearchAgenti
    {
        public AgentiSearchParameters AgentiSearchParameters { get; set; } = new();
    }
}