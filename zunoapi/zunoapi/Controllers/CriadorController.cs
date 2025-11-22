using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // exige token JWT
    public class CriadorController : ControllerBase
    {
        private readonly IRepository<Criador> _repository;

        public CriadorController(IRepository<Criador> repository)
        {
            _repository = repository;
        }

        // GET /api/criador/me
        // Retorna o criador logado
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var criadorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var criador = await _repository.GetById(criadorId);

            if (criador == null)
                return NotFound("Criador não encontrado.");

            return Ok(criador);
        }


        // PUT /api/criador/{id}
        // Só atualiza dados não sensíveis (nome, bio, foto)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Criador criador)
        {
            var criadorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != criadorId)
                return Unauthorized("Você só pode editar sua própria conta.");

            if (id != criador.Id)
                return BadRequest();

            _repository.Update(criador);
            await _repository.Save();

            return NoContent();
        }

        // DELETE /api/criador/{id}
        // O criador só pode excluir sua própria conta
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var criadorId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (id != criadorId)
                return Unauthorized("Você só pode excluir sua própria conta.");

            var criador = await _repository.GetById(id);

            if (criador == null)
                return NotFound();

            _repository.Delete(criador);
            await _repository.Save();

            return NoContent();
        }
    }
}
