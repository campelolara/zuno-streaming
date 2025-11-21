using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.Maui.Storage;
using painel_de_controle.Models;

namespace painel_de_controle.Services;

    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService()
        {
            _http = new HttpClient();
        }

            public async Task<PerfilDTO?> GetMeAsync()
        {
            var token = Preferences.Get("auth_token", null);

            if (string.IsNullOrEmpty(token))
                return null;

            var cliente = new HttpClient();
            cliente.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _http.GetAsync("https://zs3rxbr1-44387.brs.devtunnels.ms/api/CriadorAuth/me");

            if (response.IsSuccessStatusCode)
            {

                var json = await response.Content.ReadAsStringAsync();
                var perfil = JsonSerializer.Deserialize<PerfilDTO>(json);
                return perfil;

            }
            else
            {
            return null;
            }
        }
    }
