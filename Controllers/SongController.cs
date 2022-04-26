using FinalProject.Entities;
using FinalProject.Managers;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongsManager manager;
        public SongController(ISongsManager songsManager)
        {
            this.manager = songsManager;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> GetSongs()
        {
            var songs = manager.GetSongs();
            return Ok(songs);
        }

        [HttpGet("select-id")]
        public async Task<IActionResult> GetSongIds()
        {
            var idList = manager.GetSongIdsList();
            return Ok(idList);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var song = manager.GetSongById(id);
            return Ok(song);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong([FromBody] SongModel songModel)
        {
            manager.CreateSong(songModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSong([FromBody] SongModel songModel)
        {
            manager.UpdateSong(songModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong([FromRoute] int id)
        {
            manager.DeleteSong(id);
            return Ok();
        }
    }
}
