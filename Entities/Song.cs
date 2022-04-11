using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Song
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string MusicalInstrument { get; set; }
        public ICollection<StudentSong> StudentsSongs { get; set; }
    }
}
