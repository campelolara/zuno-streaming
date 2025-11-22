using Microsoft.AspNetCore.Mvc;
using zunoapi.Infra.Interface;
using zunoapi.Models;


namespace zunoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteudoController : ControllerBase
    {

        private IRepository<Conteudo> _repository;

        public ConteudoController(IRepository<Conteudo> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conteudos = await _repository.GetAll();
            return Ok(conteudos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var conteudo = await _repository.GetById(id);
            if (conteudo == null)
                return NotFound();

            return Ok(conteudo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Conteudo conteudo)
        {
            await _repository.Add(conteudo);
            await _repository.Save();
            return CreatedAtAction(nameof(GetById), new { id = conteudo.Id }, conteudo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Conteudo conteudo)
        {
            var cont = await _repository.GetById(conteudo.Id);

            if(cont == null)
                return NotFound();

            _repository.Update(conteudo);
            await _repository.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var conteudo = await _repository.GetById(id);
            if (conteudo == null)
                return NotFound();

            _repository.Delete(conteudo);
            await _repository.Save();
            return NoContent();
        }


    }
}
