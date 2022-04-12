using FinalProject.Entities;
using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public class OrganizersManager : IOrganizersManager
    {
        private readonly IOrganizersRepository organizersRepository;
        public OrganizersManager(IOrganizersRepository organizersRepository)
        {
            this.organizersRepository = organizersRepository;
        }
        public List<OrganizerModel> GetOrganizers()
        {
            var organizers = organizersRepository.GetOrganizersIQueryable()
                .Select(x => new OrganizerModel
                {
                    Id = x.Id,
                    ConcertId = x.ConcertId,
                    OrganizerName = x.OrganizerName
                })
                .ToList();
            return organizers;
        }
        public List<int> GetOrganizerIdsList()
        {
            var organizers = organizersRepository.GetOrganizersIQueryable();
            var idList = organizers.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Organizer GetOrganizerById(int id)
        {
            var organizer = organizersRepository.GetOrganizersIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return organizer;
        }

        public void CreateOrganizer(OrganizerModel organizerModel)
        {
            var newOrganizer = new Organizer
            {
                OrganizerName = organizerModel.OrganizerName
            };

            organizersRepository.CreateOrganizer(newOrganizer);
        }

        public void UpdateOrganizer(OrganizerModel organizerModel)
        {
            var organizer = GetOrganizerById(organizerModel.Id);
            organizer.OrganizerName = organizerModel.OrganizerName;
            organizersRepository.UpdateOrganizer(organizer);
        }

        public void DeleteOrganizer(int Id)
        {
            var concert = GetOrganizerById(Id);
            organizersRepository.DeleteOrganizer(concert);
        }

    }
}