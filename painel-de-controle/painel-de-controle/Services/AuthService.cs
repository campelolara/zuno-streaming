using System.IdentityModel.Tokens.Jwt;
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

    //Extrai o ID do criador do JWT
    public int? GetCreatorIdFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);

        // depende do backend → geralmente "sub" ou "id" ou "nameid"
        var idClaim = jwt.Claims.FirstOrDefault(c =>
            c.Type == "sub" || c.Type == "id" || c.Type == "nameid");

        if (idClaim == null)
            return null;

        return int.Parse(idClaim.Value);
    }

    //Salva token e ID
    public void SaveTokenAndCreatorId(string token)
    {
        Preferences.Set("auth_token", token);

        var id = GetCreatorIdFromToken(token);
        if (id.HasValue)
            Preferences.Set("creator_id", id.Value);
    }

    public async Task<PerfilDTO?> GetMeAsync()
    {
        var token = Preferences.Get("auth_token", null);

        if (string.IsNullOrEmpty(token))
            return null;

        // adiciona o token no mesmo HttpClient
        _http.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

        var response = await _http.GetAsync("https://zs3rxbr1-44387.brs.devtunnels.ms/api/CriadorAuth/me");

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PerfilDTO>(json);
    }
}
