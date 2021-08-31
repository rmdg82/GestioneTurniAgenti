using GestioneTurniAgenti.Shared.Dtos.Turno;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Components
{
    public partial class ConfirmationDeleteTurno
    {
        private string _modalDisplay;
        private bool _showBackdrop;

        public TurnoDto TurnoToShow { get; set; } = new();

        [Parameter]
        public EventCallback OnOKClicked { get; set; }

        public void Show(TurnoDto turnoDto)
        {
            TurnoToShow = turnoDto;
            _modalDisplay = "block;";
            _showBackdrop = true;
            StateHasChanged();
        }

        public void Hide()
        {
            _modalDisplay = "none;";
            _showBackdrop = false;
            StateHasChanged();
        }
    }
}