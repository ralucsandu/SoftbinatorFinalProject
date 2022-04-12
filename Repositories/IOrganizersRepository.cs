using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IOrganizersRepository
    {
        IQueryable<Organizer> GetOrganizersIQueryable();
        void CreateOrganizer(Organizer organizer);
        void UpdateOrganizer(Organizer organizer);
        void DeleteOrganizer(Organizer organizer);
    }
}