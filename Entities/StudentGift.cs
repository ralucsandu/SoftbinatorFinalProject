using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class StudentGift
    {
        public int StudentId { get; set; }
        public int GiftId { get; set; }

        public Student Student { get; set; }
        public Gift Gift { get; set; }
    }
}
