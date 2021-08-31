using GestioneTurniAgenti.Shared.Dtos.Eventi;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Components
{
    public partial class ConfirmationDeleteEvento
    {
        private string _modalDisplay;
        private bool _showBackdrop;

        public EventoDto EventoToShow { get; set; } = new();

        [Parameter]
        public EventCallback OnOKClicked { get; set; }

        public void Show(EventoDto turnoDto)
        {
            EventoToShow = turnoDto;
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