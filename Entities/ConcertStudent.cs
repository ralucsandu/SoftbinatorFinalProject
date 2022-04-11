using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class ConcertStudent
    {
        public int ConcertId { get; set; }
        public int StudentId { get; set; }

        public Concert Concert { get; set; }
        public Student Student { get; set; }
    }
}
