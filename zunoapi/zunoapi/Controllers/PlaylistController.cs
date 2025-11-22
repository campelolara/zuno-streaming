//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using zunoapi.Data;
//using zunoapi.Infra.Interface;
//using zunoapi.Models;

//namespace zunoapi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PlaylistController : ControllerBase
//    {
//        private IPlaylistRepository _repository;

//        public PlaylistController(IPlaylistRepository repository)
//        {
//            _repository = repository;
//        }
//        //falta ajeitar todo o controller
//        // ============================
//        // GET: Lista todas as playlists do usuário
//        // ============================
//        [HttpGet("{usuarioId}")]
//        public async Task<IActionResult> GetPlaylists(int usuarioId)
//        {
//            var playlists = await _repository.GetAllPlaylists(usuarioId)
//                .Where(p => p.UsuarioId == usuarioId)
//                .ToListAsync();

//            return Ok(playlists);
//        }

//        // ============================
//        // GET: Detalhes de uma playlist específica
//        // ============================
//        [HttpGet("{usuarioId}/detalhe/{playlistId}")]
//        public async Task<IActionResult> GetPlaylist(int usuarioId, int playlistId)
//        {
//            var playlist = await _db.Playlists
//                .Include(p => p.ItemPlaylists)
//                .FirstOrDefaultAsync(p => p.Id == playlistId && p.UsuarioId == usuarioId);

//            if (playlist == null)
//                return NotFound("Playlist não encontrada ou não pertence ao usuário.");

//            return Ok(playlist);
//        }

//        // ============================
//        // POST: Criar uma playlist
//        // ============================
//        [HttpPost]
//        public async Task<IActionResult> CreatePlaylist(Playlist model)
//        {
//            // Garante que o usuário existe
//            var user = await _db.Usuarios.FindAsync(model.UsuarioId);
//            if (user == null)
//                return BadRequest("Usuário inválido.");

//            _db.Playlists.Add(model);
//            await _db.SaveChangesAsync();

//            return Ok(model);
//        }

//        // ============================
//        // PUT: Editar playlist
//        // ============================
//        [HttpPut("{playlistId}")]
//        public async Task<IActionResult> UpdatePlaylist(int playlistId, Playlist model)
//        {
//            var playlist = await _db.Playlists.FindAsync(playlistId);

//            if (playlist == null)
//                return NotFound("Playlist não encontrada.");

//            // bloqueia edição caso não seja do mesmo usuário
//            if (playlist.UsuarioId != model.UsuarioId)
//                return Unauthorized("Você não pode editar uma playlist de outro usuário.");

//            playlist.Nome = model.Nome;

//            _db.Playlists.Update(playlist);
//            await _db.SaveChangesAsync();

//            return Ok(playlist);
//        }

//        // ============================
//        // DELETE: Remover uma playlist
//        // ============================
//        [HttpDelete("{usuarioId}/{playlistId}")]
//        public async Task<IActionResult> DeletePlaylist(int usuarioId, int playlistId)
//        {
//            var playlist = await _db.Playlists
//                .FirstOrDefaultAsync(p => p.Id == playlistId && p.UsuarioId == usuarioId);

//            if (playlist == null)
//                return NotFound("Playlist não encontrada ou não pertence ao usuário.");

//            _db.Playlists.Remove(playlist);
//            await _db.SaveChangesAsync();

//            return Ok("Playlist removida com sucesso.");
//        }
//    }
//}
