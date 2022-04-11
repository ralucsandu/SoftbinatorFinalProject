using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class StudentSong
    {
        public int StudentId { get; set; }
        public int SongId { get; set; }

        public Student Student { get; set; }
        public Song Song { get; set; }

    }
}
