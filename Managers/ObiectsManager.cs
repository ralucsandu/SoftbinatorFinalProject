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
    public class ObiectsManager : IObiectsManager
    {
        private readonly IObiectsRepository obiectsRepository;
        public ObiectsManager(IObiectsRepository obiectsRepository)
        {
            this.obiectsRepository = obiectsRepository;
        }
        public List<ObiectModel> GetObiects()
        {
            var obiects = obiectsRepository.GetObiectsIQueryable()
                .Select(x => new ObiectModel
                {
                    Id = x.Id,
                    GiftId = x.GiftId,
                    ObiectName = x.ObiectName
                })
                .ToList();
            return obiects;
        }
        public List<int> GetObiectIdsList()
        {
            var obiects = obiectsRepository.GetObiectsIQueryable();
            var idList = obiects.Select(x => x.Id)
                .ToList();
            return idList;
        }

        public Obiect GetObiectById(int id)
        {
            var obiects = obiectsRepository.GetObiectsIQueryable()
                .FirstOrDefault(x => x.Id == id);
            return obiects;
        }

        public void CreateObiect(ObiectModel obiectModel)
        {
            var newObiect = new Obiect
            {
                ObiectName = obiectModel.ObiectName
            };

            obiectsRepository.CreateObiect(newObiect);
        }

        public void UpdateObiect(ObiectModel obiectModel)
        {
            var obiect = GetObiectById(obiectModel.Id);
            obiect.ObiectName = obiectModel.ObiectName;
            obiectsRepository.UpdateObiect(obiect);
        }

        public void DeleteObiect(int Id)
        {
            var obiect = GetObiectById(Id);
            obiectsRepository.DeleteObiect(obiect);
        }
    }
}