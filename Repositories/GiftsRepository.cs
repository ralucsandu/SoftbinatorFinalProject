using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class GiftsRepository : IGiftsRepository
    {
        private FinalProjectContext db;

        public GiftsRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Gift> GetGiftsIQueryable()
        {
            var gifts = db.Gifts;
            return gifts;
        }

        public void CreateGift(Gift gift)
        {
            db.Gifts.Add(gift);
            db.SaveChanges();
        }

        public void DeleteGift(Gift gift)
        {
            db.Gifts.Remove(gift);
            db.SaveChanges();
        }

    }
}
