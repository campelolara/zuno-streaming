using Microsoft.AspNetCore.Mvc;
using zunoapi.Infra.Interface;
using zunoapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zunoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudoController : ControllerBase
    {

        private IRepository<Criador> _repository;

        public ConteudoController(IRepository<Criador> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var criadores = await _repository.GetAll();
            return Ok(criadores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var criador = await _repository.GetById(id);
            if (criador == null)
                return NotFound();

            return Ok(criador);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Criador criador)
        {
            await _repository.Add(criador);
            await _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = criador.Id }, criador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Criador criador)
        {
            if (id != criador.Id)
                return BadRequest();

            _repository.Update(criador);
            await _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var criador = await _repository.GetById(id);
            if (criador == null)
                return NotFound();

            _repository.Delete(criador);
            await _repository.Save();
            return NoContent();
        }


    }
}
