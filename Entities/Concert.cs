using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities

{
    public class Concert
    {
        public int Id { get; set; }
        public string ConcertName { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public Organizer Organizer { get; set; }
        public ICollection<ConcertStudent> ConcertsStudents { get; set; }
         
    }
}
