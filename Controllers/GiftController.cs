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
    public class GiftController : ControllerBase
    {
        private readonly IGiftsManager manager;
        public GiftController(IGiftsManager giftsManager)
        {
            this.manager = giftsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetGifts()
        {
            var gifts = manager.GetGifts();
            return Ok(gifts);
        }

        [HttpGet("select-id")]
        public async Task<IActionResult> GetGiftIds()
        {
            var idList = manager.GetGiftIdsList();
            return Ok(idList);
        }

        [HttpGet("byId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var gift = manager.GetGiftById(id);
            return Ok(gift);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGift([FromBody] GiftModel giftModel)
        {
            manager.CreateGift(giftModel);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift([FromRoute] int id)
        {
            manager.DeleteGift(id);
            return Ok();
        }
    }
}
