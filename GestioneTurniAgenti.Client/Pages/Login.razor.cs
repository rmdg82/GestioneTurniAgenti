using GestioneTurniAgenti.Client.Services;
using GestioneTurniAgenti.Shared.Dtos.Authentication;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Pages
{
    public partial class Login
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        private UserForAuthenticationDto _userForAuthenticationDto = new();

        public bool ShowAuthErrors { get; set; }
        public string Error { get; set; }

        public async Task ExecuteLogin()
        {
            ShowAuthErrors = false;

            var result = await AuthenticationService.Login(_userForAuthenticationDto);
            if (!result.IsAuthSuccessful)
            {
                Error = result.ErrorMessage;
                ShowAuthErrors = true;
            }
            else
            {
                NavigationManager.NavigateTo("/anagrafica");
            }
        }
    }
}