using Microsoft.AspNetCore.Mvc;
using zunoapi.Infra.DTO;
using zunoapi.Infra.Interface;
using zunoapi.Models;

namespace zunoapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : ControllerBase
    {
        private IPlaylistRepository _repository;

        public PlaylistController(IPlaylistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("todas")]
        public List<PlaylistDTO> GetPlaylists()
        {
            var playlists = _repository.GetAllPlaylist();

            var playlistDTOs = playlists.Select(p => new PlaylistDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                UsuarioId = p.UsuarioId
            }).ToList();

            return playlistDTOs;
        }

        [HttpGet("detalhe/{playlistId}")]
        public PlaylistDTO GetPlaylist(int playlistId)
        {
            var playlist = _repository.GetPlaylistByID(playlistId);

            if (playlist == null)
                return null;

            var playlistDTO = new PlaylistDTO
            {
                Id = playlist.Id,
                Nome = playlist.Nome,
                UsuarioId = playlist.UsuarioId
            };

            return playlistDTO;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> CreatePlaylist(PlaylistDTO model)
        {
            var playlist = new Playlist
            {
                Nome = model.Nome,
                UsuarioId = model.UsuarioId
            };

            _repository.AddPlaylist(playlist);
            await _repository.Save();

            return Ok(model);
        }

        [HttpPut("editar/{playlistId}")]
        public async Task<IActionResult> UpdatePlaylist(int playlistId, PlaylistDTO model)
        {
            var playlist = _repository.GetPlaylistByID(playlistId);

            if (playlist == null)
                return NotFound("Playlist não encontrada.");

            playlist.Nome = model.Nome;

            _repository.UpdatePlaylist(playlist);
            await _repository.Save();

            return Ok(new PlaylistDTO
            {
                Id = playlist.Id,
                Nome = playlist.Nome,
                UsuarioId = playlist.UsuarioId
            });
        }

        [HttpDelete("excluir/{playlistId}")]
        public async Task<IActionResult> DeletePlaylist(int playlistId)
        {
            var playlist = _repository.GetPlaylistByID(playlistId);

            if (playlist == null)
                return NotFound("Playlist não encontrada.");

            _repository.DeletePlaylist(playlist);
            await _repository.Save();

            return Ok("Playlist removida com sucesso.");
        }
    }
}
