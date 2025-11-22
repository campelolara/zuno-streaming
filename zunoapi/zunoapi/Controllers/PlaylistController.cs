using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using zunoapi.Data;
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

        // pega todas as playlists
        [HttpGet]
        public List<Playlist> GetPlaylists()
        {
            var playlists =  _repository.GetAllPlaylist();

            return playlists;
        }

        [HttpGet("{usuarioId}/detalhe/{playlistId}")]
        public Playlist GetPlaylist(int usuarioId, int playlistId)
        {
            var playlist =  _repository.GetPlaylistByID(playlistId);

            return playlist;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(Playlist model)
        {           
            _repository.AddPlaylist(model);
            await _repository.Save();

            return Ok(model);
        }

        [HttpPut("{playlistId}")]
        public async Task<IActionResult> UpdatePlaylist(int playlistId, Playlist model)
        {
            var playlist = _repository.GetPlaylistByID(playlistId);

            if (playlist == null)
                return NotFound("Playlist não encontrada.");

            // bloqueia edição caso não seja do mesmo usuário
            if (playlist.UsuarioId != model.UsuarioId)
                return Unauthorized("Você não pode editar uma playlist de outro usuário.");

            playlist.Nome = model.Nome;

            _repository.UpdatePlaylist(playlist);
            await _repository.Save();

            return Ok(playlist);
        }

        [HttpDelete("{usuarioId}/{playlistId}")]
        public async Task<IActionResult> DeletePlaylist(int usuarioId, int playlistId)
        {
            var playlist = _repository.GetPlaylistByID(playlistId);

            if (playlist == null)
                return NotFound("Playlist não encontrada ou não pertence ao usuário.");

            _repository.DeletePlaylist(playlist);
            await _repository.Save();

            return Ok("Playlist removida com sucesso.");
        }
    }
}
