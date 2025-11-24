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
