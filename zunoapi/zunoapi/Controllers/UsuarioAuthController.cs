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
    public class UsuarioAuthController : ControllerBase
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IConfiguration _config;

        public UsuarioAuthController(IRepository<Usuario> repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        // REGISTRAR
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioAuthDTO dto)
        {
            var existe = (await _repository.GetAll())
                .Any(u => u.Email.ToLower() == dto.Email.ToLower());

            if (existe)
                return BadRequest("Email já cadastrado.");

            CriarSenha(dto.Senha, out byte[] hash, out byte[] salt);

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            await _repository.Add(usuario);
            await _repository.Save();

            return Ok("Usuário criado com sucesso.");
        }

        // LOGIN
        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioAuthDTO dto)
        {
            var usuarios = await _repository.GetAll();
            var usuario = usuarios.FirstOrDefault(u => u.Email == dto.Email);

            if (usuario == null)
                return Unauthorized("Email incorreto.");

            if (!VerificarSenha(dto.Senha, usuario.PasswordHash, usuario.PasswordSalt))
                return Unauthorized("Senha incorreta.");

            var token = GerarToken(usuario);

            return Ok(new { token });
        }

        // AUXILIARES
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

        private string GerarToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email)
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

        // GET: api/usuarioauth/me
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (usuarioId == null)
                return Unauthorized();

            var usuario = await _repository.GetById(int.Parse(usuarioId));

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email
            });
        }
    }
}
