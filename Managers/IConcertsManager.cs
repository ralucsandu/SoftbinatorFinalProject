using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface IConcertsManager
    {
        List<ConcertModel> GetConcerts();
        List<int> GetConcertIdsList();
        Concert GetConcertById(int id);
        void CreateConcert(ConcertModel concertModel);
        void UpdateConcert(ConcertModel concertModel);
        void DeleteConcert(int ConcertId);

    }
}