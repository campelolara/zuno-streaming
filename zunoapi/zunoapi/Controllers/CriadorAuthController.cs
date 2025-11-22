using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using zunoapi.Infra.DTO;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriadorAuthController : ControllerBase
    {
        private readonly IRepository<Criador> _repository;
        private readonly IConfiguration _config;

        public CriadorAuthController(IRepository<Criador> repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        // REGISTRAR
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(CriadorAuthDTO dto)
        {
            // Verificar se email já existe
            var existe = (await _repository
                .GetAll())
                .Any(c => c.Email.ToLower() == dto.Email.ToLower());

            if (existe)
                return BadRequest("Email já cadastrado.");

            // Criar hash da senha
            CriarSenha(dto.Senha, out byte[] hash, out byte[] salt);

            var criador = new Criador
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _repository.Add(criador);
            await _repository.Save();

            return Ok("Criado com sucesso.");
        }


        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(CriadorAuthDTO dto)
        {
            var criadores = await _repository.GetAll();
            var criador = criadores.FirstOrDefault(c => c.Email == dto.Email);

            if (criador == null)
                return Unauthorized("Email incorreto.");

            if (!VerificarSenha(dto.Senha, criador.PasswordHash, criador.PasswordSalt))
                return Unauthorized("Senha incorreta.");

            var token = GerarToken(criador);

            return Ok(token);
        }


        // MÉTODOS AUXILIARES
        private void CriarSenha(string senha, out byte[] hash, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
        }

        private bool VerificarSenha(string senha, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var hashComputado = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return hashComputado.SequenceEqual(hash);
        }

        private string GerarToken(Criador criador)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, criador.Id.ToString()),
                new Claim(ClaimTypes.Name, criador.Nome),
                new Claim(ClaimTypes.Email, criador.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // GET: api/auth/me
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            // Pega o ID do criador logado pelo token JWT
            var criadorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (criadorId == null)
                return Unauthorized();

            var criador = await _repository.GetById(int.Parse(criadorId));

            if (criador == null)
                return NotFound("Criador não encontrado.");

            return Ok(new
            {
                criador.Id,
                criador.Nome,
                criador.Email
            });
        }
    }
}
