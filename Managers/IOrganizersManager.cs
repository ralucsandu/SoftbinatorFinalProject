using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface IOrganizersManager
    {
        List<OrganizerModel> GetOrganizers();
        List<int> GetOrganizerIdsList();
        Organizer GetOrganizerById(int id);
        void CreateOrganizer(OrganizerModel organizerModel);
        void UpdateOrganizer(OrganizerModel organizerModel);
        void DeleteOrganizer(int OrganizerId);

    }
}