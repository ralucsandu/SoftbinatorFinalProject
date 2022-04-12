using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class ConcertsRepository : IConcertsRepository
    {
        private FinalProjectContext db;

        public ConcertsRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Concert> GetConcertsIQueryable()
        {
            var concerts = db.Concerts;
            return concerts;
        }

        public void CreateConcert(Concert concert)
        {
            db.Concerts.Add(concert);
            db.SaveChanges();
        }

        public void UpdateConcert(Concert concert)
        {
            db.Concerts.Update(concert);
            db.SaveChanges();
        }

        public void DeleteConcert(Concert concert)
        {
            db.Concerts.Remove(concert);
            db.SaveChanges();
        }

    }
}