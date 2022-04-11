using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities

{
    public class Organizer
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public string OrganizerName { get; set; }
        public Concert Concert { get; set; }

    }
}
