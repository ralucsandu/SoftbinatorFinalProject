using FinalProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class OrganizersRepository : IOrganizersRepository
    {
        private FinalProjectContext db;

        public OrganizersRepository(FinalProjectContext db)
        {
            this.db = db;
        }

        public IQueryable<Organizer> GetOrganizersIQueryable()
        {
            var organizers = db.Organizers;
            return organizers;
        }

        public void CreateOrganizer(Organizer organizer)
        {
            db.Organizers.Add(organizer);
            db.SaveChanges();
        }

        public void UpdateOrganizer(Organizer organizer)
        {
            db.Organizers.Update(organizer);
            db.SaveChanges();
        }

        public void DeleteOrganizer(Organizer organizer)
        {
            db.Organizers.Remove(organizer);
            db.SaveChanges();
        }

    }
}