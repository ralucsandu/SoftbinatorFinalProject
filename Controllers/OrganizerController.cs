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
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizersManager manager;
        public OrganizerController(IOrganizersManager organizersManager)
        {
            this.manager = organizersManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrganizers()
        {
            var organizers = manager.GetOrganizers();
            return Ok(organizers);
        }
        [HttpGet("select-organizer-id")]
        public async Task<IActionResult> GetOrganizerIds()
        {
            var idList = manager.GetOrganizerIdsList();
            return Ok(idList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganizer([FromBody] OrganizerModel organizersManager)
        {
            manager.CreateOrganizer(organizersManager);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrganizer([FromBody] OrganizerModel organizersManager)
        {
            manager.UpdateOrganizer(organizersManager);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer([FromRoute] int id)
        {
            manager.DeleteOrganizer(id);
            return Ok();
        }
    }
}