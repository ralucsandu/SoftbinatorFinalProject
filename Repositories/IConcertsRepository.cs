using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IConcertsRepository
    {
        IQueryable<Concert> GetConcertsIQueryable();
        void CreateConcert(Concert concert);
        void UpdateConcert(Concert concert);
        void DeleteConcert(Concert concert);
    }
}