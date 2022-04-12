using FinalProject.Entities;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Managers
{
    public interface IObiectsManager
    {
        List<ObiectModel> GetObiects();
        List<int> GetObiectIdsList();
        Obiect GetObiectById(int id);
        void CreateObiect(ObiectModel obiectModel);
        void UpdateObiect(ObiectModel obiectModel);
        void DeleteObiect(int ObiectId);

    }
}