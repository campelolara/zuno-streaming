using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace SuaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepository<Usuario> _repository;

        public UsuarioController(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        // GET /api/usuario/me
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var usuario = await _repository.GetById(usuarioId);

            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            return Ok(usuario);
        }

        // PUT /api/usuario/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Usuario usuario)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != usuarioId)
                return Unauthorized("Você só pode editar sua própria conta.");

            if (id != usuario.Id)
                return BadRequest();

            _repository.Update(usuario);
            await _repository.Save();

            return NoContent();
        }

        // DELETE /api/usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != usuarioId)
                return Unauthorized("Você só pode excluir sua própria conta.");

            var usuario = await _repository.GetById(id);

            if (usuario == null)
                return NotFound();

            _repository.Delete(usuario);
            await _repository.Save();

            return NoContent();
        } 
    }
}
