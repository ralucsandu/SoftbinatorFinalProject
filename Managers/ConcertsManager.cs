using FinalProject.Entities;
using FinalProject.Models;
using FinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public class ConcertsManager : IConcertsManager
    {
        private readonly IConcertsRepository concertsRepository;
        public ConcertsManager(IConcertsRepository concertsRepository)
        {
            this.concertsRepository = concertsRepository;
        }
        public List<ConcertModel> GetConcerts()
        {
            var concerts = concertsRepository.GetConcertsIQueryable()
                .Select(x => new ConcertModel
                {
                    Id = x.Id,
                    ConcertName = x.ConcertName,
                    Date = x.Date,
                    Location = x.Location
                })
                .ToList();
            return concerts;
        }
        public List<int> GetConcertIdsList()
        {
            var concerts = concertsRepository.GetConcertsIQueryable();
            var idList = concerts.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Concert GetConcertById(int id)
        {
            var concert = concertsRepository.GetConcertsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return concert;
        }

        public void CreateConcert(ConcertModel concertModel)
        {
            var newConcert = new Concert
            {
                ConcertName = concertModel.ConcertName,
                Date = concertModel.Date,
                Location = concertModel.Location
            };

            concertsRepository.CreateConcert(newConcert);
        }

        public void UpdateConcert(ConcertModel concertModel)
        {
            var concert = GetConcertById(concertModel.Id);
            concert.ConcertName = concertModel.ConcertName;
            concert.Date = concertModel.Date;
            concert.Location = concertModel.Location;
            concertsRepository.UpdateConcert(concert);
        }

        public void DeleteConcert(int Id)
        {
            var concert = GetConcertById(Id);
            concertsRepository.DeleteConcert(concert);
        }

    }
}