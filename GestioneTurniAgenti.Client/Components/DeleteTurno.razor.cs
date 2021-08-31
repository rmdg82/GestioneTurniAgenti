using Blazored.Modal;
using Blazored.Modal.Services;
using GestioneTurniAgenti.Client.Pages;
using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Components
{
    public partial class DeleteTurno
    {
        [CascadingParameter]
        private BlazoredModalInstance ModalInstance { get; set; }

        [Parameter]
        public Guid TurnoId { get; set; }

        [Inject]
        public ITurniService TurniService { get; set; }

        public TurnoDto TurnoToDelete { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TurnoToDelete = await TurniService.GetTurnoById(TurnoId);
        }

        public async Task ConfirmDeletion()
        {
            await TurniService.DeleteTurno(TurnoId);
            await ModalInstance.CloseAsync();
        }
    }
}