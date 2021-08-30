using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Turno
{
    public class TurnoForUpdateDto
    {
        [Required]
        public Guid AgenteId { get; set; }

        [Required]
        public Guid EventoId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [MaxLength(500, ErrorMessage = "Lunghezza massima di 500 caratteri.")]
        public string Note { get; set; }
    }
}