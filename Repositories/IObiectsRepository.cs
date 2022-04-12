using FinalProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IObiectsRepository
    {
        IQueryable<Obiect> GetObiectsIQueryable();
        void CreateObiect(Obiect obiect);
        void UpdateObiect(Obiect obiect);
        void DeleteObiect(Obiect obiect);
    }
}