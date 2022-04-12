using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ConcertModel
    {   
        public int Id { get; set; }

        public string ConcertName { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }

    }
}