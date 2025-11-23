using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPlaylistController : ControllerBase
    {
        private IRepository<ItemPlaylist> _repository;

        public ItemPlaylistController(IRepository<ItemPlaylist> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itens = await _repository.GetAll();
            return Ok(itens);
        }
            

        [HttpPost]
        public async Task<IActionResult> Create(ItemPlaylist item)
        {
            await _repository.Add(item);
            await _repository.Save();
            return Ok("Adicionado com sucesso");
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
                return NotFound();

            _repository.Delete(item);
            await _repository.Save();
            return NoContent();
        }

    }
}
