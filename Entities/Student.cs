using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ConcertStudent> ConcertsStudents { get; set; }
        public ICollection<StudentGift> StudentsGifts { get; set; }
        public ICollection<StudentSong> StudentsSongs { get; set; }
    }
}
