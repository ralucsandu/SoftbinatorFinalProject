using FinalProject.Entities;
using FinalProject.Managers;
using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObiectController : ControllerBase
    {
        private readonly IObiectsManager manager;
        public ObiectController(IObiectsManager obiectsManager)
        {
            this.manager = obiectsManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetObiects()
        {
            var obiects = manager.GetObiects();
            return Ok(obiects);
        }
        [HttpGet("select-obiect-id")]
        public async Task<IActionResult> GetObiectIds()
        {
            var idList = manager.GetObiectIdsList();
            return Ok(idList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateObiect([FromBody] ObiectModel obiectsManager)
        {
            manager.CreateObiect(obiectsManager);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateObiect([FromBody] ObiectModel obiectsManager)
        {
            manager.UpdateObiect(obiectsManager);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObiect([FromRoute] int id)
        {
            manager.DeleteObiect(id);
            return Ok();
        }
    }
}