using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Shared.Dtos.Eventi
{
    public class EventoForUpdateDto : IValidatableObject
    {
        [Required(ErrorMessage = "Nome è un campo obligatorio.")]
        public string Nome { get; set; }

        public DateTime Inizio { get; set; }
        public DateTime Fine { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Fine < Inizio)
            {
                yield return new ValidationResult("La data di fine deve essere successiva alla data di inizio.");
            }
        }
    }
}