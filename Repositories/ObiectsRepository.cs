using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class ObiectsRepository : IObiectsRepository
    {
        private FinalProjectContext db;

        public ObiectsRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Obiect> GetObiectsIQueryable()
        {
            var obiects = db.Obiects;
            return obiects;
        }

        public void CreateObiect(Obiect obiect)
        {
            db.Obiects.Add(obiect);
            db.SaveChanges();
        }

        public void UpdateObiect(Obiect obiect)
        {
            db.Obiects.Update(obiect);
            db.SaveChanges();
        }

        public void DeleteObiect(Obiect obiect)
        {
            db.Obiects.Remove(obiect);
            db.SaveChanges();
        }

    }
}