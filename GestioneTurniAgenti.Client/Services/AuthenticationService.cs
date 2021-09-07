using Blazored.LocalStorage;
using GestioneTurniAgenti.Client.AuthProviders;
using GestioneTurniAgenti.Shared.Dtos.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Client.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorageService, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _localStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
            _authStateProvider = authStateProvider ?? throw new ArgumentNullException(nameof(authStateProvider));
        }

        public async Task<AuthenticationResponseDto> Login(UserForAuthenticationDto userForAuthenticationDto)
        {
            var response = await _httpClient.PostAsJsonAsync("account/login", userForAuthenticationDto);
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<AuthenticationResponseDto>(content, _options);

            if (!response.IsSuccessStatusCode)
                return result;

            await _localStorageService.SetItemAsync("authToken", result.Token);
            await _localStorageService.SetItemAsStringAsync("nomeReparto", result.NomeReparto);
            await _localStorageService.SetItemAsync("repartoId", result.RepartoId);
            ((JwtAuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return new AuthenticationResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorageService.RemoveItemAsync("authToken");
            await _localStorageService.RemoveItemAsync("nomeReparto");
            await _localStorageService.RemoveItemAsync("repartoId");
            ((JwtAuthStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}