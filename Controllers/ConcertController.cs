using FinalProject.Entities;
using FinalProject.Managers;
using FinalProject.Models;
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
    public class ConcertController : ControllerBase
    {
        private readonly IConcertsManager manager;
        public ConcertController(IConcertsManager concertsManager)
        {
            this.manager = concertsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetConcerts()
        {
            var concerts = manager.GetConcerts();
            return Ok(concerts);
        }

        [HttpGet("select-id")] 
        public async Task<IActionResult> GetConcertIds()
        {
            var idList = manager.GetConcertIdsList();
            return Ok(idList);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var concert = manager.GetConcertById(id);
            return Ok(concert);
        }

        [HttpPost]
        public async Task<IActionResult> CreateConcert([FromBody] ConcertModel concertModel)
        {
            manager.CreateConcert(concertModel);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConcert([FromBody] ConcertModel concertModel)
        {
            manager.UpdateConcert(concertModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcert([FromRoute] int id)
        {
            manager.DeleteConcert(id);
            return Ok();
        }
    }
}